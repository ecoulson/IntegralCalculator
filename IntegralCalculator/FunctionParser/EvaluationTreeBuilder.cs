using System;
using IntegralCalculator.FunctionParser.Terms;
using IntegralCalculator.Streams;
using IntegralCalculator.Exceptions;

namespace IntegralCalculator.FunctionParser
{
    public class EvaluationTreeBuilder
    {
        private TermStream termStream;

        public EvaluationTreeBuilder(TermStream termStream) {
            this.termStream = termStream;
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
                Console.WriteLine(((OperatorTerm)operatorNode.getTerm()).getOperator());
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
            return !termStream.isEndOfStream() && termStream.isNextTermExponent();
        }

        private EvaluationNode readExponentOperator() {
            if (termStream.isNextTermExponent()) {
                return readTerm();
            } else {
                throw new IllegalTermException();
            }
        }

        private bool shouldReadFactor() {
            return !termStream.isEndOfStream() && termStream.isNextTermFactorOperator();
        }

        private EvaluationNode readFactorOperator() {
            if (termStream.isNextTermFactorOperator()) {
                return readTerm();
            } else {
                throw new IllegalTermException();
            }
        }

        private bool shouldReadSum() {
            return !termStream.isEndOfStream() && termStream.isNextTermSumOperator() && !termStream.isNextTermRightParentheses();
        }

        private EvaluationNode readSumOperator() {
            if (termStream.isNextTermSumOperator()) {
                return readTerm();
            } else {
                throw new IllegalTermException();
            }
        }

        private EvaluationNode readTerm() {
            if (termStream.isNextTermLeftParentheses()) {
                termStream.read();
                EvaluationNode node = readSums();
                termStream.read();
                return node;
            } else {
                return new EvaluationNode(termStream.read());   
            }
        }
    }
}
