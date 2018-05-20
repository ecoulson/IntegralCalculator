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
                operatorNode.right = node;
                operatorNode.left = readFactors();
                node = operatorNode;
            }
            return node;
        }

        private SyntaxNode readFactors() {
            SyntaxNode node = readExponents();
            while (shouldReadFactor()) {
                SyntaxNode operatorNode = readFactorOperator();
                operatorNode.right = node;
                operatorNode.left = readExponents();
                node = operatorNode;
            }
            return node;
        }

        private SyntaxNode readExponents() {
            SyntaxNode node = readToken();
            while (shouldReadExponent()) {
                SyntaxNode operatorNode = readExponentOperator();
                operatorNode.right = node;
                operatorNode.left = readToken();
                node = operatorNode;
            }
            return node;
        }

        private bool shouldReadExponent() {
            return !tokenStream.isEndOfStream() && tokenStream.isNextTokenExponent();
        }

        private SyntaxNode readExponentOperator() {
            if (tokenStream.isNextTokenExponent()) {
                return readToken();
            } else {
                throw new IllegalTokenException("Illegal Token type: " + tokenStream.peek().getTokenType());
            }
        }

        private bool shouldReadFactor() {
            return !tokenStream.isEndOfStream() && tokenStream.isNextTokenFactorOperator();
        }

        private SyntaxNode readFactorOperator() {
            if (tokenStream.isNextTokenFactorOperator()) {
                return readToken();
            } else {
                throw new IllegalTokenException("Illegal Token type: " + tokenStream.peek().getTokenType());
            }
        }

        private bool shouldReadSum() {
            return !tokenStream.isEndOfStream() && tokenStream.isNextTokenSumOperator() && !tokenStream.isNextTokenRightParentheses();
        }

        private SyntaxNode readSumOperator() {
            if (tokenStream.isNextTokenSumOperator()) {
                return readToken();
            } else {
                throw new IllegalTokenException("Illegal Token type: " + tokenStream.peek().getTokenType());
            }
        }

        private SyntaxNode readToken() {
            if (tokenStream.isNextTokenLeftParentheses()) {
                tokenStream.read();
                SyntaxNode node = readSums();
                tokenStream.read();
                return node;
            } else {
                return new SyntaxNode(tokenStream.read());   
            }
        }
    }
}
