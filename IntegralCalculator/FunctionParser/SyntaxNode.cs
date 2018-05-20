using System;
using IntegralCalculator.FunctionParser.Terms;

namespace IntegralCalculator.FunctionParser
{
    public class SyntaxNode
    {
        private Token token;

        public SyntaxNode left;
        public SyntaxNode right;

        public SyntaxNode(Token token) {
            this.token = token;
        }

        public SyntaxNode(Token token, SyntaxNode left, SyntaxNode right) {
            this.token = token;
            this.left = left;
            this.right = right;
        }

        public Token getToken() {
            return token;
        }

        public TokenType getTokenType() {
            return token.getTokenType();
        }

        public override string ToString()
        {
            return "[EvaluationNode] Term: " + token.getTokenType();
        }
    }
}
