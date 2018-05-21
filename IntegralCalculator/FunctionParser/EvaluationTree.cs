using System;
using IntegralCalculator.FunctionParser.EvaluationNodes;

namespace IntegralCalculator.FunctionParser
{
    public class EvaluationTree
    {
        private EvaluationTreeBuilder treeBuilder;
        private EvaluationNode root;
        private double x;

        public EvaluationTree(SemanticTree semanticTree) {
            this.treeBuilder = new EvaluationTreeBuilder(semanticTree);
            this.root = treeBuilder.build();
        }

        public EvaluationTree(EvaluationNode root) {
            this.root = root;
        }

        public double evaluate(double x) {
            this.x = x;
            return evaluate(this.root);
        }

        public double evaluate(EvaluationNode node) {
            if (node == null) {
                return 0;
            } else if (node.getNodeType() == EvaluationNodeType.NUMBER) {
                NumberNode numberNode = (NumberNode)node;
                return numberNode.evaluate();
            } else if (node.getNodeType() == EvaluationNodeType.VARIABLE) {
                VariableNode variableNode = (VariableNode)node;
                return variableNode.evaluate(x);
            } else if (node.getNodeType() == EvaluationNodeType.FUNCTION) {
                FunctionNode functionNode = (FunctionNode)node;
                return functionNode.evaluate(x);
            } else {
                OperatorNode operatorNode = (OperatorNode)node;
                double a = evaluate(node.left);
                double b = evaluate(node.right);
                return operatorNode.evaluate(a, b);
            }
        }
    }
}
