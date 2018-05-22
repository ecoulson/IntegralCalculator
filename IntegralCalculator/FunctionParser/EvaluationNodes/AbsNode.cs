using System;
namespace IntegralCalculator.FunctionParser.EvaluationNodes
{
    public class AbsNode : FunctionNode
    {
        public AbsNode()
        {
        }

        public override double evaluate(double x) {
            return Math.Abs(x);
        }
    }
}
