using System;
using IntegralCalculator.FunctionParser.Terms;
using IntegralCalculator.Streams;
using IntegralCalculator.Exceptions;

namespace IntegralCalculator.FunctionParser
{
    public class EvaluationTreeBuilder
    {
        private TokenStream tokenStream;

        public EvaluationTreeBuilder(TokenStream tokenStream) {
            this.tokenStream = tokenStream;
        }

        public EvaluationNode buildTree() {
            return readSums();
        }

        private EvaluationNode readSums() {
            EvaluationNode node = readFactors();
            while (shouldReadSum()) {
                EvaluationNode operatorNode = readSumOperator();
                operatorNode.left = node;
                operatorNode.right = readFactors();
                node = operatorNode;
            }
            return node;
        }

        private EvaluationNode readFactors() {
            EvaluationNode node = readExponents();
            while (shouldReadFactor()) {
                EvaluationNode operatorNode = readFactorOperator();
                operatorNode.left = node;
                operatorNode.right = readExponents();
                node = operatorNode;
            }
            return node;
        }

        private EvaluationNode readExponents() {
            EvaluationNode node = readTerm();
            while (shouldReadExponent()) {
                EvaluationNode operatorNode = readExponentOperator();
                operatorNode.left = node;
                operatorNode.right = readTerm();
                node = operatorNode;
            }
            return node;
        }

        private bool shouldReadExponent() {
            return !tokenStream.isEndOfStream() && tokenStream.isNextTokenExponent();
        }

        private EvaluationNode readExponentOperator() {
            if (tokenStream.isNextTokenExponent()) {
                return readTerm();
            } else {
                throw new IllegalTermException();
            }
        }

        private bool shouldReadFactor() {
            return !tokenStream.isEndOfStream() && tokenStream.isNextTokenFactorOperator();
        }

        private EvaluationNode readFactorOperator() {
            if (tokenStream.isNextTokenFactorOperator()) {
                return readTerm();
            } else {
                throw new IllegalTermException();
            }
        }

        private bool shouldReadSum() {
            return !tokenStream.isEndOfStream() && tokenStream.isNextTokenSumOperator() && !tokenStream.isNextTokenRightParentheses();
        }

        private EvaluationNode readSumOperator() {
            if (tokenStream.isNextTokenSumOperator()) {
                return readTerm();
            } else {
                throw new IllegalTermException();
            }
        }

        private EvaluationNode readTerm() {
            if (tokenStream.isNextTokenLeftParentheses()) {
                tokenStream.read();
                EvaluationNode node = readSums();
                tokenStream.read();
                return node;
            } else {
                return new EvaluationNode(tokenStream.read());   
            }
        }
    }
}
