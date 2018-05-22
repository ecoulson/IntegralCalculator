using System;
namespace IntegralCalculator.FunctionParser.EvaluationNodes
{
	public class LnNode : FunctionNode
    {
        public LnNode()
        {
        }

        public override double evaluate(double x) {
            return Math.Log(x);
        }
    }
}
