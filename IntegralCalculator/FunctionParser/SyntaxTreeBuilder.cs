using System;
using IntegralCalculator.Streams;
using IntegralCalculator.Exceptions;

namespace IntegralCalculator.FunctionParser
{
    public class SyntaxTreeBuilder
    {
        private TokenStream tokenStream;

        public SyntaxTreeBuilder(TokenStream tokenStream) {
            this.tokenStream = tokenStream;
        }

        public SyntaxNode buildTree() {
            return readSums();
        }

        private SyntaxNode readSums() {
            SyntaxNode node = readFactors();
            while (shouldReadSum()) {
                SyntaxNode operatorNode = readSumOperator();
                operatorNode.left = node;
                operatorNode.right = readFactors();
                node = operatorNode;
            }
            return node;
        }

        private SyntaxNode readFactors() {
            SyntaxNode node = readNegatives();
            while (shouldReadFactor()) {
                SyntaxNode operatorNode = readFactorOperator();
                operatorNode.left = node;
                operatorNode.right = readNegatives();
                node = operatorNode;
            }
            return node;
        }

        private SyntaxNode readNegatives() {
            if (shouldReadNegative()) {
                return readNegativeSubtree();
            } else {
                return readExponents();
            }
        }

        private bool shouldReadNegative() {
            return !tokenStream.isEndOfStream() && tokenStream.isNextTokenMinusSign();
        }

        private SyntaxNode readNegativeSubtree() {
            SyntaxNode node = readNegativeOperator();
            node.right = SyntaxNode.createOppositeNode();
            while (shouldReadNegative()) {
                SyntaxNode operatorNode = readNegativeOperator();
                node.left = SyntaxNode.createOppositeNode();
                operatorNode.right = node;
                node = operatorNode;
            }
            node.left = readExponents();
            return node;
        }

        private SyntaxNode readNegativeOperator() {
            if (tokenStream.isNextTokenMinusSign()) {
                return readTransformedNegativeNode();
            } else {
                throw new IllegalTokenException("Illegal Token type: " + tokenStream.peek().getTokenType());
            }
        }

        private SyntaxNode readExponents() {
            SyntaxNode node = readParentheses();
            while (shouldReadExponent()) {
                SyntaxNode operatorNode = readExponentOperator();
                operatorNode.left = node;
                operatorNode.right = readParentheses();
                node = operatorNode;
            }
            return node;
        }

        private SyntaxNode readParentheses() {
            if (shouldReadParentheses()) {
                tokenStream.read();
                SyntaxNode node = readSums();
                tokenStream.read();
                return node;
            } else {
                return readNode();
            }
        }

        private bool shouldReadParentheses() {
            return !tokenStream.isEndOfStream() &&
                               tokenStream.isNextTokenLeftParentheses();
        }

        private bool shouldReadExponent() {
            return !tokenStream.isEndOfStream() && tokenStream.isNextTokenExponent();
        }

        private SyntaxNode readExponentOperator() {
            if (tokenStream.isNextTokenExponent()) {
                return readNode();
            } else {
                throw new IllegalTokenException("Illegal Token type: " + tokenStream.peek().getTokenType());
            }
        }

        private SyntaxNode readTransformedNegativeNode() {
            SyntaxNode node = readNode();
            node.setSymbol("*");
            node.transformToken(TokenType.OPERATOR);
            return node;
        }

        private bool shouldReadFactor() {
            return !tokenStream.isEndOfStream() && tokenStream.isNextTokenFactorOperator();
        }

        private SyntaxNode readFactorOperator() {
            if (tokenStream.isNextTokenFactorOperator()) {
                return readNode();
            } else {
                throw new IllegalTokenException("Illegal Token type: " + tokenStream.peek().getTokenType());
            }
        }

        private bool shouldReadSum() {
            return !tokenStream.isEndOfStream() && 
                               tokenStream.isNextTokenSumOperator() && 
                               !tokenStream.isNextTokenRightParentheses();
        }

        private SyntaxNode readSumOperator() {
            if (tokenStream.isNextTokenSumOperator()) {
                return readNode();
            } else {
                throw new IllegalTokenException("Illegal Token type: " + tokenStream.peek().getTokenType());
            }
        }

        private SyntaxNode readNode() {
            SyntaxNode node = new SyntaxNode(tokenStream.read());
            if (node.getTokenType() == TokenType.IDENTIFIER && shouldReadParentheses()){
                return readInvokeNode(node);
            } else {
                return node;
            }
        }

        private SyntaxNode readInvokeNode(SyntaxNode node) {
            SyntaxNode invokeNode = SyntaxNode.createInvokeNode();
            invokeNode.right = readParentheses();
            invokeNode.left = node;
            node = invokeNode;
            return node;
        }
    }
}
