using System;
using IntegralCalculator.Exceptions;
using IntegralCalculator.Streams;

namespace IntegralCalculator.FunctionParser
{
    public class Declaration
    {
        private TokenStream tokenStream;

        private string name;
        private char variable;

        public Declaration(string declaration) {
            ExpressionLexer lexer = new ExpressionLexer(declaration);
            this.tokenStream = lexer.lex();
            parseDeclaration();
        }

        private void parseDeclaration() {
            this.name = readName();
            readLeftParentheses();
            this.variable = readVariable();
            readRightParentheses();
        }

        private string readName() {
            Token token = readIdentifier();
            Symbol symbol = token.getSymbol();
            return symbol.getValue();
        }

        private Token readIdentifier() {
            if (tokenStream.isNextTokenIdentifier()) {
                Token token = tokenStream.read();
                return token;
            } else {
                throw new IllegalTokenException("Expected Identifier Token Instead Found TokenType: " + tokenStream.peek().getTokenType());
            }
        }

        private Token readLeftParentheses() {
            if (tokenStream.isNextTokenLeftParentheses()) {
                return tokenStream.read();
            } else {
                throw new IllegalTokenException("Expected Left Parentheses Token Instead Found TokenType: " + tokenStream.peek().getTokenType());
            }
        }

        private char readVariable() {
            if (tokenStream.isNextTokenVariable()) {
                Token token = tokenStream.read();
                Symbol symbol = token.getSymbol();
                return symbol.getValue()[0];
            } else {
                throw new IllegalTokenException("Expected Variable Token Instead Found TokenType: " + tokenStream.peek().getTokenType());
            }
        }

        private Token readRightParentheses() {
            if (tokenStream.isNextTokenRightParentheses()) {
                return tokenStream.read();
            } else {
                throw new IllegalTokenException("Expected Right Parentheses Token Instead Found TokenType: " + tokenStream.peek().getTokenType());
            }
        }

        public string getName() {
            return name;
        }

        public char getVariable() {
            return variable;
        }
    }
}
