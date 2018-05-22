using System;
namespace IntegralCalculator.FunctionParser.EvaluationNodes
{
    public class ArctanNode : FunctionNode
    {
        public ArctanNode()
        {
        }

        public override double evaluate(double x)
        {
            return Math.Atan(x);
        }
    }
}
