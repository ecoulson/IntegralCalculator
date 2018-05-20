using System;

using IntegralCalculator.Streams;

namespace IntegralCalculator.FunctionParser
{
    public class SyntaxTree
    {
        private SyntaxNode root;
        private SyntaxTreeBuilder treeBuilder;

        public SyntaxTree(TokenStream tokenStream) {
            this.treeBuilder = new SyntaxTreeBuilder(tokenStream);
            this.root = treeBuilder.buildTree();
            Console.WriteLine(this.root.left.getToken().getSymbol().getValue());
        }

        public void analyze() {
            
        }
    }
}
