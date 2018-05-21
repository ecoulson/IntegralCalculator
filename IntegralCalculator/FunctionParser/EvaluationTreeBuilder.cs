using System;
using IntegralCalculator.FunctionParser.EvaluationNodes;
using IntegralCalculator.App;

namespace IntegralCalculator.FunctionParser
{
    public class EvaluationTreeBuilder
    {
        private SemanticTree semanticTree;

        public EvaluationTreeBuilder(SemanticTree semanticTree) {
            this.semanticTree = semanticTree;
        }

        public EvaluationNode build() {
            return build(semanticTree.getRoot());
        }

        private EvaluationNode build(SemanticNode node) {
            if (node == null) {
                return null;
            } else if (isNodeVariable(node)) {
                return readVariableNode(node);
            } else if (isNodeNumber(node)) {
                return readNumberNode(node);
            } else if (isNodeFunction(node)) {
                return readFunctionNode(node);
            } else {
                EvaluationNode newRoot = new OperatorNode(node.getToken());
                newRoot.left = build(node.left);
                newRoot.right = build(node.right);
                return newRoot;
            }
        }

        private bool isNodeNumber(SemanticNode node) {
            return node.getTokenType() == TokenType.NUMBER;
        }

        private NumberNode readNumberNode(SemanticNode node) {
            double n = double.Parse(node.getSymbolValue());
            return new NumberNode(n);
        }

        private bool isNodeVariable(SemanticNode node) {
            return node.getTokenType() == TokenType.VARIABLE;
        }

        private VariableNode readVariableNode(SemanticNode node) {
            return new VariableNode();
        }

        private bool isNodeOperator(SemanticNode node) {
            return node.getTokenType() == TokenType.OPERATOR;
        }

        private OperatorNode readOperatorNode(SemanticNode node) {
            return new OperatorNode(node.getToken());
        }

        private bool isNodeFunction(SemanticNode node) {
            return node.getTokenType() == TokenType.INVOKE;
        }

        private FunctionNode readFunctionNode(SemanticNode node) {
            Function function = getFunction(node.left);
            EvaluationNode parameterRoot = build(node.right);
            EvaluationTree evaluationTree = new EvaluationTree(parameterRoot);
            return new FunctionNode(function, evaluationTree);
        }

        private Function getFunction(SemanticNode node) {
            string functionName = node.getSymbolValue();
            if (Calculator.currentNameSpace.hasFunction(functionName)) {
                return Calculator.currentNameSpace.getFunction(functionName);
            } else if (Calculator.globalNameSpace.hasFunction(functionName)) {
                return Calculator.globalNameSpace.getFunction(functionName);
            } else {
                throw new Exception();
            }
        }
    }
}
