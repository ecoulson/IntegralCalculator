using System;
namespace IntegralCalculator.FunctionParser.Terms
{
    public class OperatorTerm: Term
    {
        private OperatorType op;

        public OperatorTerm(OperatorType op):base(TermType.OPERATOR) {
            this.op = op;
        }

        public override double evaluate(double a, double b) {
            return doOperation(a, b);
        }

        private double doOperation(double a, double b) {
            switch (op) {
                case OperatorType.ADD:
                    return a + b;
                case OperatorType.SUBTRACT:
                    return a - b;
                case OperatorType.MULTIPLY:
                    return a * b;
                case OperatorType.DIVIDE:
                    return a / b;
                case OperatorType.EXPONENT:
                    return Math.Pow(a, b);
                default:
                    throw new UnknownSymbolException();
            }
        }

        public OperatorType getOperator() {
            return op;
        }

        public override string ToString()
        {
            return string.Format("[OperatorTerm]: " + op);
        }
    }
}
