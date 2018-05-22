using System;
namespace IntegralCalculator.FunctionParser.EvaluationNodes
{
    public class TanNode : FunctionNode
    {
        public TanNode() {
        }

        public override double evaluate(double x) {
            return Math.Tan(x);
        }
    }
}
