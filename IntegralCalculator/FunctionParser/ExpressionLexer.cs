using System;
using System.Collections.Generic;

using IntegralCalculator.Streams;

namespace IntegralCalculator.FunctionParser {
    public class ExpressionLexer {
        private CharacterStream characterStream;
        private TokenStream tokenStream;

        public ExpressionLexer(string expression) {
            this.characterStream = new CharacterStream(expression);
            this.tokenStream = new TokenStream();
        }

        public TokenStream lex() {
            while(!characterStream.isEndOfStream()) {
                addToken();
            }
            return tokenStream;
        }

        private void addToken() {
            Token token = readToken();
            if (token.getTokenType() != TokenType.WHITESPACE) {
                tokenStream.write(token);
            }
        }

        private Token readToken() {
            TokenType type = getTokenType();
            Symbol symbol = readSymbol(type);
            return new Token(symbol, type);
        }

        private TokenType getTokenType() {
            if (characterStream.isNextCharWhiteSpace()) {
                return TokenType.WHITESPACE;
            } else if (characterStream.isNextCharEulersConstant()) {
                return TokenType.EULERS_CONSTANT;
            } else if (characterStream.isNextCharLetter()) {
                return TokenType.IDENTIFIER;
            } else if (characterStream.isNextCharDigit()) {
                return TokenType.NUMBER;
            } else if (characterStream.isNextCharOperator()) {
                return TokenType.OPERATOR;
            } else if (characterStream.isNextCharLeftParentheses()) {
                return TokenType.LEFT_PARENTHESES;
            } else if (characterStream.isNextCharRightParentheses()) {
                return TokenType.RIGHT_PARENTHESES;
            } else {
                throw new UnknownSymbolException("Unknown Symbol: " + characterStream.peek());
            }
        }

        private Symbol readSymbol(TokenType type) {
            switch(type) {
                case TokenType.NUMBER:
                    return readNumber();
                case TokenType.IDENTIFIER:
                    return readIdentifier();
                case TokenType.OPERATOR:
                    return readOperator();
                case TokenType.WHITESPACE:
                    return readWhiteSpace();
                case TokenType.LEFT_PARENTHESES:
                case TokenType.RIGHT_PARENTHESES:
                    return readParentheses();
                case TokenType.EULERS_CONSTANT:
                    return readEulersConstant();
                default:
                    throw new UnknownTokenException("Unknown Token " + type);
            }
        }

        private Symbol readNumber() {
            string number = "";
            while (shouldReadDigit()) {
                number += characterStream.read();
            }
            return new Symbol(number);
        }

        private bool shouldReadDigit() {
            return !characterStream.isEndOfStream() && characterStream.isNextCharDigit();
        }

        private Symbol readIdentifier() {
            string identifier = "";
            while(shouldReadLetter()) {
                identifier += characterStream.read();
            }
            return new Symbol(identifier);
        }

        private bool shouldReadLetter() {
            return !characterStream.isEndOfStream() && characterStream.isNextCharLetter();
        }

        private Symbol readOperator() {
            return readSymbol();
        }

        private Symbol readWhiteSpace() {
            return readSymbol();
        }

        private Symbol readParentheses() {
            return readSymbol();
        }

        private Symbol readEulersConstant() {
            characterStream.read();
            return new Symbol(Math.E.ToString());
        }

        private Symbol readSymbol() {
            string symbol = characterStream.readAsString();
            return new Symbol(symbol);
        }
    }
}
