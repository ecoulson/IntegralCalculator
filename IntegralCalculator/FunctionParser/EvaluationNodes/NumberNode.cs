using System;
namespace IntegralCalculator.FunctionParser.EvaluationNodes
{
    public class NumberNode : EvaluationNode
    {
        private double number;

        public NumberNode(double number): base(EvaluationNodeType.NUMBER) {
            this.number = number;
        }

        public override double evaluate() {
            return number;
        }
    }
}
