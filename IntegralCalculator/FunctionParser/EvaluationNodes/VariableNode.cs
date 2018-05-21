using System;
namespace IntegralCalculator.FunctionParser.EvaluationNodes
{
    public class VariableNode : EvaluationNode
    {
        public VariableNode() : base(EvaluationNodeType.VARIABLE) {
        }

        public override double evaluate(double x) {
            return x;
        }
    }
}
