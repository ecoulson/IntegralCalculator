using System;

using IntegralCalculator.FunctionParser.Terms;
using IntegralCalculator.Streams;

namespace IntegralCalculator.FunctionParser
{
    public class EvaluationTree
    {
        private EvaluationNode root;
        private EvaluationTreeBuilder treeBuilder;

        public EvaluationTree(TermStream termStream) {
            this.treeBuilder = new EvaluationTreeBuilder(termStream);
            this.root = treeBuilder.buildTree();
        }

        public double evaluate(double x) {
            return evaluate(x, root);
        }

        private double evaluate(double x, EvaluationNode node) {
            if (isConstantTerm(node)) {
                ConstantTerm term = getConstantTerm(node);
                return term.evaluate();
            } else if (isAlgebraicTerm(node)) {
                AlgebraicTerm term = getAlgebraicTerm(node);
                return term.evaluate(x);
            } else {
                OperatorTerm term = getOperatorTerm(node);
                double a = evaluate(x, node.left);
                double b = evaluate(x, node.right);
                return term.evaluate(a, b);
            }
        }

        private bool isConstantTerm(EvaluationNode node) {
            return node.getTermType() == TermType.CONSTANT;
        }

        private ConstantTerm getConstantTerm(EvaluationNode node) {
            return (ConstantTerm)node.getTerm();
        }

        private bool isAlgebraicTerm(EvaluationNode node) {
            return node.getTermType() == TermType.ALGEBRAIC;
        }

        private AlgebraicTerm getAlgebraicTerm(EvaluationNode node) {
            return (AlgebraicTerm)node.getTerm();
        }

        private OperatorTerm getOperatorTerm(EvaluationNode node) {
            return (OperatorTerm)node.getTerm();
        }
    }
}
