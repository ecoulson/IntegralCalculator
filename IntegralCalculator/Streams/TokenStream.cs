using System;
using System.Collections.Generic;
using IntegralCalculator.FunctionParser;
using IntegralCalculator.FunctionParser.Terms;

namespace IntegralCalculator.Streams
{
    public class TokenStream : Stream<Token>
    {
        private List<Token> tokens;

        public TokenStream():base(0) {
            this.tokens = new List<Token>();
        }

        public override Token read() {
            int index = cursor.getPosition();
            cursor.incrementPosition();
            return tokens[index];
        }

        public override void write(Token token) {
            int size = length();
            tokens.Add(token);
            resize(size + 1);
        }

        public override void seek(int offset) {
            cursor.setPosition(offset);
        }

        public Token peek() {
            int oldPosition = cursor.getPosition();
            Token token = read();
            seek(oldPosition);
            return token;
        }

        public bool isNextTokenOperator() {
            return isNextTypeOf(TokenType.OPERATOR);
        }

        public bool isNextTokenIdentifier() {
            return isNextTypeOf(TokenType.IDENTIFIER);
        }

        public bool isNextTokenVariable() {
            if (isNextTokenIdentifier()) {
                Token token = peek();
                Symbol symbol = token.getSymbol();
                string value = symbol.getValue();
                return value.Length == 1;
            } else {
                return false;
            }
        }

        public bool isNextTokenNumber() {
            return isNextTypeOf(TokenType.NUMBER);
        }

        public bool isNextTokenRightParentheses() {
            return isNextTypeOf(TokenType.RIGHT_PARENTHESES);
        }

        public bool isNextTokenLeftParentheses() {
            return isNextTypeOf(TokenType.LEFT_PARENTHESES);
        }

        private bool isNextTypeOf(TokenType type) {
            Token token = peek();
            return token.getTokenType() == type;
        }
    }
}
