using System;
namespace IntegralCalculator.FunctionParser.EvaluationNodes
{
    public class OperatorNode : EvaluationNode
    {
        private Operator op;

        public OperatorNode(Token token) : base(EvaluationNodeType.OPERATOR) {
            this.op = new Operator(token);
        }

        public override double evaluate(double a, double b) {
            return op.doOperation(a, b);
        }
    }
}
