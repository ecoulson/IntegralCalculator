using System;
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

        public string getTokenValue() {
            return token.getSymbol().getValue();
        }

        public void transformToken(TokenType tokenType) {
            token.transform(tokenType);
        }

        public void setSymbol(string symbol) {
            token.getSymbol().setSymbol(symbol);
        }

        public string getSymbolValue() {
            return token.getSymbol().getValue();
        }

        public override string ToString() {
            return "[SyntaxNode] Token: " + token.getTokenType();
        }

        public static SyntaxNode createOppositeNode() {
            Symbol symbol = new Symbol("-1");
            Token oppositeToken = new Token(symbol, TokenType.NUMBER);
            return new SyntaxNode(oppositeToken);
        }
    }
}
