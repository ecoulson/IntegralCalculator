using System;
namespace IntegralCalculator.FunctionParser.Terms 
{
    public class AlgebraicTerm: Term 
    {
        private double coefficient;
        private char variable;

        public AlgebraicTerm(double coefficient, char variable): base(TermType.ALGEBRAIC) {
            this.coefficient = coefficient;
            this.variable = variable;
        }

        public char getVariable() {
            return variable;
        }

        public override double evaluate(double x) {
            return coefficient * x;
        }

        public override string ToString()
        {
            return string.Format("[AlgebraicTerm]: " + coefficient + variable);
        }
    }
}
