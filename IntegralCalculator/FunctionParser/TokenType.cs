using System;
namespace IntegralCalculator.FunctionParser
{
    public enum TokenType
    {
        WHITESPACE,
        NUMBER,
        IDENTIFIER,
        OPERATOR,
        LEFT_PARENTHESES,
        RIGHT_PARENTHESES,
        ABSOLUTE_VALUE,
        EULERS_CONSTANT
    }
}
