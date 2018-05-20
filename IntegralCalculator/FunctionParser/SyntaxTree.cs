using System;

using IntegralCalculator.FunctionParser.Terms;
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
        }

        public EvaluationTree buildEvaluationTree() {
            return null;
        }

        //public double evaluate(double x) {
        //    return evaluate(x, root);
        //}

        //private double evaluate(double x, EvaluationNode node) {
        //    if (isConstantTerm(node)) {
        //        ConstantTerm term = getConstantTerm(node);
        //        return term.evaluate();
        //    } else if (isAlgebraicTerm(node)) {
        //        AlgebraicTerm term = getAlgebraicTerm(node);
        //        return term.evaluate(x);
        //    } else {
        //        OperatorTerm term = getOperatorTerm(node);
        //        double a = evaluate(x, node.left);
        //        double b = evaluate(x, node.right);
        //        return term.evaluate(a, b);
        //    }
        //}

        //private bool isConstantTerm(EvaluationNode node) {
        //    return node.getTermType() == TermType.CONSTANT;
        //}

        //private ConstantTerm getConstantTerm(EvaluationNode node) {
        //    return (ConstantTerm)node.getTerm();
        //}

        //private bool isAlgebraicTerm(EvaluationNode node) {
        //    return node.getTermType() == TermType.ALGEBRAIC;
        //}

        //private AlgebraicTerm getAlgebraicTerm(EvaluationNode node) {
        //    return (AlgebraicTerm)node.getTerm();
        //}

        //private OperatorTerm getOperatorTerm(EvaluationNode node) {
        //    return (OperatorTerm)node.getTerm();
        //}
    }
}
