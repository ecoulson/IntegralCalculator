using System;
namespace IntegralCalculator.FunctionParser.EvaluationNodes
{
    public class SinNode : FunctionNode
    {
        public SinNode()
        {
        }

        public override double evaluate(double x) {
            return Math.Sin(x);
        }
    }
}
