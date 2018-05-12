using System;
namespace IntegralCalculator
{
    public class IntegralCalculator
    {
        public IntegralCalculator() {
        }

        public double calculateDefiniteIntegral(Function function, Interval interval) {
            Integral integral = new Integral(function, interval);
            return integral.integrate();
        }
    }
}
