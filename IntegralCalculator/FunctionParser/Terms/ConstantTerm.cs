using System;
namespace IntegralCalculator.FunctionParser.Terms
{
    public class ConstantTerm: Term
    {
        private double constant;

        public ConstantTerm(double constant): base(TermType.CONSTANT) {
            this.constant = constant;
        }

        public override double evaluate() {
            return constant;
        }

        public override string ToString() {
            return string.Format("[ConstantTerm]: " + constant);
        }
    }
}
