using System;
using System.Collections.Generic;
using IntegralCalculator.FunctionParser;
using IntegralCalculator.FunctionParser.Terms;

namespace IntegralCalculator.Streams
{
    public class TermStream : Stream<Term>
    {
        private List<Term> terms;

        public TermStream(): base(0) {
            this.terms = new List<Term>();
        }

        public override Term read() {
            int index = cursor.getPosition();
            cursor.incrementPosition();
            return terms[index];
        }

        public override void write(Term term) {
            terms.Add(term);
            resize(length() + 1);
        }

        public override void seek(int offset) {
            cursor.setPosition(offset);
        }

        public Term peek() {
            int oldPosition = cursor.getPosition();
            Term term = read();
            seek(oldPosition);
            return term;
        }

        public bool isNextTermParentheses() {
            return isNextTypeOf(TermType.PARENTHESES);
        }

        public bool isNextTermRightParentheses() {
            if (isNextTermParentheses()) {
                ParenthesesTerm term = (ParenthesesTerm)peek();
                return term.getParenthesesType() == TokenType.RIGHT_PARENTHESES;
            } else {
                return false;
            }
        }

        public bool isNextTermLeftParentheses() {
            if (isNextTermParentheses()) {
                ParenthesesTerm term = (ParenthesesTerm)peek();
                return term.getParenthesesType() == TokenType.LEFT_PARENTHESES;
            } else {
                return false;
            }
        }

        public bool isNextTermOperator() {
            return isNextTypeOf(TermType.OPERATOR);
        }

        public bool isNextTermSumOperator() {
            return isNextTermAddOperator() || isNextTermSubtractOperator();
        }

        private bool isNextTermAddOperator() {
            return isNextTermOperatorTypeOf(OperatorType.ADD);
        }

        private bool isNextTermSubtractOperator() {
            return isNextTermOperatorTypeOf(OperatorType.SUBTRACT);
        }

        public bool isNextTermFactorOperator() {
            return isNextTermMultiplyOperator() || isNextTermDivideOperator();
        }

        private bool isNextTermMultiplyOperator() {
            return isNextTermOperatorTypeOf(OperatorType.MULTIPLY);
        }

        private bool isNextTermDivideOperator() {
            return isNextTermOperatorTypeOf(OperatorType.DIVIDE);
        }

        public bool isNextTermExponent() {
            return isNextTermOperatorTypeOf(OperatorType.EXPONENT);
        }

        private bool isNextTermOperatorTypeOf(OperatorType operatorType) {
            if (isNextTermOperator()) {
                return peekOperator() == operatorType;
            } else {
                return false;
            }
        }

        private bool isNextTypeOf(TermType termType) {
            Term term = peek();
            return term.getTermType() == termType;
        }

        private OperatorType peekOperator() {
            OperatorTerm term = (OperatorTerm)peek();
            return term.getOperator();
        }
    }
}
