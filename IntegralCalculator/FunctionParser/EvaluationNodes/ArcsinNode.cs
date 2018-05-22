using System;
namespace IntegralCalculator.FunctionParser.EvaluationNodes
{
    public class ArcsinNode : FunctionNode
    {
        public ArcsinNode()
        {
        }

        public override double evaluate(double x) {
            return Math.Asin(x);
        }
    }
}
