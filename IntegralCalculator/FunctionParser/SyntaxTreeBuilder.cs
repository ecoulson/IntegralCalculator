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
            SyntaxNode node = readExponents();
            while (shouldReadFactor()) {
                SyntaxNode operatorNode = readFactorOperator();
                operatorNode.left = node;
                operatorNode.right = readExponents();
                node = operatorNode;
            }
            return node;
        }

        private SyntaxNode readExponents() {
            SyntaxNode node = readNode();
            while (shouldReadExponent()) {
                SyntaxNode operatorNode = readExponentOperator();
                operatorNode.left = node;
                operatorNode.right = readNode();
                node = operatorNode;
            }
            return node;
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
            return !tokenStream.isEndOfStream() && tokenStream.isNextTokenSumOperator() && !tokenStream.isNextTokenRightParentheses();
        }

        private SyntaxNode readSumOperator() {
            if (tokenStream.isNextTokenSumOperator()) {
                return readNode();
            } else {
                throw new IllegalTokenException("Illegal Token type: " + tokenStream.peek().getTokenType());
            }
        }

        private SyntaxNode readNode() {
            bool isNegative = shouldHandleNegative();

            if (tokenStream.isNextTokenLeftParentheses()) {
                return readParentheses(isNegative);
            } else {
                return readToken(isNegative);
            }
        }

        private bool shouldHandleNegative() {
            bool isNegative = tokenStream.isNextTokenMinusSign();
            if (isNegative) {
                tokenStream.read();
            }
            return isNegative;
        }

        private SyntaxNode readParentheses(bool isNegative) {
            tokenStream.read();
            SyntaxNode node = readSums();
            if (isNegative) {
                node = handleNegative(node);
            }
            tokenStream.read();
            return node;
        }

        private SyntaxNode handleNegative(SyntaxNode node) {
            Symbol operatorSymbol = new Symbol("*");
            Token operatorToken = new Token(operatorSymbol, TokenType.OPERATOR);
            SyntaxNode negativeNode = new SyntaxNode(operatorToken);
            negativeNode.left = node;
            Symbol negativeSymbol = new Symbol("-");
            Token negativeToken = new Token(negativeSymbol, TokenType.NEGATIVE);
            negativeNode.right = new SyntaxNode(negativeToken);
            node = negativeNode;
            return node;
        }

        private SyntaxNode readToken(bool isNegative) {
            SyntaxNode node = new SyntaxNode(tokenStream.read());
            if (isNegative) {
                handleNegative(node);
            }
            return node;   
        }
    }
}
