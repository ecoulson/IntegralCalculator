using System;

using IntegralCalculator.Exceptions;

namespace IntegralCalculator.FunctionParser
{
    public class Operator {
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
    }
}
