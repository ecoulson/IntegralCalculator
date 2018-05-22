using System;
using IntegralCalculator.App;

namespace IntegralCalculator.FunctionParser.EvaluationNodes
{
    public class FunctionNode : EvaluationNode
    {
        private Function function;
        private EvaluationTree evaluationTree;

        public FunctionNode(Function function, EvaluationTree evaluationTree) : base(EvaluationNodeType.FUNCTION) {
            this.function = function;
            this.evaluationTree = evaluationTree;
        }

        public FunctionNode():base(EvaluationNodeType.FUNCTION) {
            
        }

        public override double evaluate(double x){
            double newX = evaluationTree.evaluate(x);
            return function.calculateY(newX);
        }
    }
}
