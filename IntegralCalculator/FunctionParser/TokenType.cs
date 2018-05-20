using System;
namespace IntegralCalculator.FunctionParser
{
    public enum TokenType
    {
        WHITESPACE,
        IDENTIFIER,
        NUMBER,
        OPERATOR,
        LEFT_PARENTHESES,
        RIGHT_PARENTHESES,
        ABSOLUTE_VALUE,
        VARIABLE,
        NEGATIVE,
    }
}
