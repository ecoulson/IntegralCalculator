using System;

using IntegralCalculator.Exceptions;

namespace IntegralCalculator.FunctionParser
{
    public class Operator {
        private OperatorType operatorType;

        public Operator(Token token) {
            this.operatorType = getOperatorTypeFromToken(token);
        }

        public static OperatorType getOperatorTypeFromToken(Token token) {
            Symbol symbol = token.getSymbol();
            char op = char.Parse(symbol.getValue());
            switch (op) {
                case '+':
                    return OperatorType.ADD;
                case '-':
                    return OperatorType.SUBTRACT;
                case '*':
                    return OperatorType.MULTIPLY;
                case '/':
                    return OperatorType.DIVIDE;
                case '^':
                    return OperatorType.EXPONENT;
                default:
                    throw new UnknownSymbolException("Uknown Operator of type " + op);
            }
        }

        public double doOperation(double a, double b) {
            switch (operatorType) {
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
                    throw new Exception();
            }
        }
    }
}
