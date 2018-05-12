using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace IntegralCalculator
{
    public class ExpressionLexer
    {
        /*
         * Tokens
         * 1. number
         * 2. variable
         * 3. operator
         * 4. whitespace
         */
        private Regex WHITE_SPACE = new Regex("\\w");

        private string expression;

        public ExpressionLexer(string expression) {
            this.expression = expression;
        }

        public List<Token> lex() {
            List<Token> tokens = new List<Token>();
            for (int i = 0; i < expression.Length;i ++) {
                Token token = createToken(expression[i]);
                tokens.Add(token);
            }
            //Console.WriteLine(tokens.Count);
            return tokens;
        }

        private Token createToken(char ch) {
            string charString = ch + "";
            if (WHITE_SPACE.IsMatch(charString)) {
                return null;
            } else {
                return new Token();
            }
        }
    }
}
