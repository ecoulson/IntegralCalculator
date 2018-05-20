using System;
using IntegralCalculator.Exceptions;
using IntegralCalculator.Streams;

namespace IntegralCalculator.FunctionParser
{
    public class Declaration
    {
        private TokenStream tokenStream;

        private string name;
        private char varaible;

        public Declaration(string declaration) {
            ExpressionLexer lexer = new ExpressionLexer(declaration);
            this.tokenStream = lexer.lex();
            parseDeclaration();
        }

        private void parseDeclaration() {
            this.name = readName();
            readLeftParentheses();
            this.varaible = readVariable();
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
                throw new IllegalTokenException();
            }
        }

        private Token readLeftParentheses() {
            if (tokenStream.isNextTokenLeftParentheses()) {
                return tokenStream.read();
            } else {
                throw new IllegalTokenException();
            }
        }

        private char readVariable() {
            if (tokenStream.isNextTokenVariable()) {
                Token token = tokenStream.read();
                Symbol symbol = token.getSymbol();
                return symbol.getValue()[0];
            } else {
                throw new IllegalTokenException();
            }
        }

        private Token readRightParentheses() {
            if (tokenStream.isNextTokenRightParentheses()) {
                return tokenStream.read();
            } else {
                throw new IllegalTokenException();
            }
        }

        public string getName() {
            return name;
        }

        public char getVariable() {
            return varaible;
        }
    }
}
