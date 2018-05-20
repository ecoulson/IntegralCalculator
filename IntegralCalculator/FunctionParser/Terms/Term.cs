using System;
namespace IntegralCalculator.FunctionParser.Terms 
{
    public abstract class Term {
        private TermType termType;

        public Term(TermType termType) {
            this.termType = termType;
        }

        public virtual double evaluate() {
            throw new NotImplementedException();
        }

        public virtual double evaluate(double x) {
            throw new NotImplementedException();   
        }

        public virtual double evaluate(double a, double b) {
            throw new NotImplementedException();
        }

        public TermType getTermType() {
            return termType;
        }
    }
}
