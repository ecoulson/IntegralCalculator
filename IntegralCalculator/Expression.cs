using System;
namespace IntegralCalculator
{
    public class Expression
    {
        public Expression() {
        }

        public double evaluate(double x) {
            return x * x + 2 * x + 1;
        }
    }
}
