using System;
namespace IntegralCalculator.FunctionParser
{
    public class SemanticNode
    {
        private Token token;
        public SemanticNode left;
        public SemanticNode right;

        public SemanticNode(Token token) {
            this.token = token;
        }
    }
}
