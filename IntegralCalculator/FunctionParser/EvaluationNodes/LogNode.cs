using System;
namespace IntegralCalculator.FunctionParser.EvaluationNodes
{
    public class LogNode : FunctionNode
    {
        public LogNode()
        {
        }

        public override double evaluate(double x) {
            return Math.Log10(x);
        }
    }
}
