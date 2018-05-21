using System;
namespace IntegralCalculator.FunctionParser.EvaluationNodes
{
    public abstract class EvaluationNode
    {
        private EvaluationNodeType nodeType;
        public EvaluationNode left;
        public EvaluationNode right;

        public EvaluationNode(EvaluationNodeType nodeType) {
            this.nodeType = nodeType;
        }

        public EvaluationNodeType getNodeType() {
            return this.nodeType;
        }

        public virtual double evaluate() {
            // hi evan i love you -Tara :) - Evan
            throw new NotImplementedException();
        }

        public virtual double evaluate(double x) {
            throw new NotImplementedException();
        }

        public virtual double evaluate(double a, double b) {
            throw new NotImplementedException();
        }
    }
}
