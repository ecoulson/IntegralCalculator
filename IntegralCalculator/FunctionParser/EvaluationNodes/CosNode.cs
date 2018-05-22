using System;
namespace IntegralCalculator.FunctionParser.EvaluationNodes
{
    public class CosNode : FunctionNode
    {
        public CosNode() {
        }

        public override double evaluate(double x) {
            return Math.Cos(x);
        }
    }
}
