using System;
namespace IntegralCalculator.FunctionParser {
    public class Token {
        private Symbol symbol;
        private TokenType tokenType;

        public Token(Symbol symbol, TokenType tokenType) {
            this.symbol = symbol;
            this.tokenType = tokenType;
        }

        public TokenType getTokenType() {
            return tokenType;
        }

        public Symbol getSymbol() {
            return symbol;
        }
    }
}
