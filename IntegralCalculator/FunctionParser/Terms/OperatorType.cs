using System;
using IntegralCalculator.FunctionParser;
using IntegralCalculator.Exceptions;

namespace IntegralCalculator.FunctionParser.Terms
{
    public enum OperatorType
    {
        ADD,
        SUBTRACT,
        MULTIPLY,
        DIVIDE,
        EXPONENT,
        LOG,
        LN,
        SIN,
        COS,
        TAN,
        SEC,
        CSC,
        COT,
    }

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
