using System;
namespace IntegralCalculator.FunctionParser
{
    public class EvaluationTree
    {
        private EvaluationTreeBuilder treeBuilder;
        private EvaluationNode root;

        public EvaluationTree(SyntaxTree syntaxTree) {
            this.treeBuilder = new EvaluationTreeBuilder(syntaxTree);
            this.root = treeBuilder.build();
        }

        public double evaluate(double x) {
            return 5;
        }
    }
}
