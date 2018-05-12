using System;
using System.Collections.Generic;
namespace IntegralCalculator
{
    public class ExpressionParser
    {
        private string expression;

        public ExpressionParser(string expression) {
            this.expression = expression;
        }

        public Expression parse() {
            ExpressionLexer lexer = new ExpressionLexer(expression);
            List<Token> expressionTokens = lexer.lex();
            return new Expression();
        }
    }
}
