using System;
namespace IntegralCalculator.FunctionParser.Terms
{
    public class ParenthesesTerm : Term
    {
        private TokenType parenthesesType;

        public ParenthesesTerm(TokenType parenthesesType): base(TermType.PARENTHESES) {
            this.parenthesesType = parenthesesType;
        }

        public TokenType getParenthesesType() {
            return parenthesesType;
        }
    }
}
