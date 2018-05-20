using System;

using IntegralCalculator.Streams;

namespace IntegralCalculator.FunctionParser
{
    public class SyntaxTree
    {
        private SyntaxNode root;
        private SyntaxTreeBuilder treeBuilder;
        private CharacterStream currentCharacterStream;

        public SyntaxTree(TokenStream tokenStream) {
            this.treeBuilder = new SyntaxTreeBuilder(tokenStream);
            this.root = treeBuilder.buildTree();
        }

        public void analyze() {
            this.root = analyze(root);
        }

        private void printNode(SyntaxNode node) {
            Console.WriteLine(node.getToken().getSymbol().getValue());
        }

        private SyntaxNode analyze(SyntaxNode node) {
            if (node.getTokenType() == TokenType.IDENTIFIER) {
                string identifier = node.getToken().getSymbol().getValue();
                currentCharacterStream = new CharacterStream(identifier);
                return parseIdentifier();
            } else {
                SyntaxNode newNode = new SyntaxNode(node.getToken());
                SyntaxNode left = analyze(node.left);
                SyntaxNode right = analyze(node.right);
                newNode.left = left;
                newNode.right = right;
                return newNode;
            }
        }

        private SyntaxNode parseIdentifier() {
            SyntaxNode node = readNode();
            while (!currentCharacterStream.isEndOfStream()) {
                Token operatorToken = new Token(new Symbol("*"), TokenType.OPERATOR);
                SyntaxNode operatorNode = new SyntaxNode(operatorToken);
                operatorNode.left = node;
                operatorNode.right = readNode();
                node = operatorNode;
            }
            return node;
        }

        private SyntaxNode readNode() {
            if (currentCharacterStream.isNextCharDigit()) {
                return readNumber();
            } else if (currentCharacterStream.isNextCharEuler()) {
                return readEuler();
            } else if (currentCharacterStream.isNextCharVariable()) {
                return readVariable();
            } else {
                throw new UnknownSymbolException("Unrecognized Symbol " + currentCharacterStream.readAsString());
            }
        }

        private SyntaxNode readNumber() {
            string number = "";
            while (shouldReadNumber()) {
                number += currentCharacterStream.readAsString();
            }
            Symbol numberSymbol = new Symbol(number);
            Token numberToken = new Token(numberSymbol, TokenType.NUMBER);
            return new SyntaxNode(numberToken);
        }

        private bool shouldReadNumber() {
            return !currentCharacterStream.isEndOfStream() && currentCharacterStream.isNextCharDigit();
        }

        private SyntaxNode readEuler() {
            currentCharacterStream.read();
            Symbol eulerSymbol = new Symbol(Math.E.ToString());
            Token eulerToken = new Token(eulerSymbol, TokenType.NUMBER);
            return new SyntaxNode(eulerToken);
        }

        private SyntaxNode readVariable() {
            string variable = currentCharacterStream.readAsString();
            Symbol variableSymbol = new Symbol(variable);
            Token variableToken = new Token(variableSymbol, TokenType.VARIABLE);
            return new SyntaxNode(variableToken);
        }
    }
}
