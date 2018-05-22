using System;
namespace IntegralCalculator.FunctionParser.EvaluationNodes
{
    public class ArccosNode : FunctionNode
    {
        public ArccosNode()
        {
        }

        public override double evaluate(double x) {
            return Math.Acos(x);
        }
    }
}
