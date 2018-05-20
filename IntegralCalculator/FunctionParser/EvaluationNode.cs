using System;
using IntegralCalculator.FunctionParser.Terms;

namespace IntegralCalculator.FunctionParser
{
    public class EvaluationNode
    {
        private Term term;

        public EvaluationNode left;
        public EvaluationNode right;

        public EvaluationNode(Term term) {
            this.term = term;
        }

        public EvaluationNode(Term term, EvaluationNode left, EvaluationNode right) {
            this.term = term;
            this.left = left;
            this.right = right;
        }

        public Term getTerm() {
            return term;
        }

        public TermType getTermType() {
            return term.getTermType();
        }

        public override string ToString()
        {
            return "[EvaluationNode] Term: " + term.getTermType();
        }
    }
}
