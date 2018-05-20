using System;
namespace IntegralCalculator.App
{
    public class Calculator
    {
        public Calculator() {
        }

        public double calculateDefiniteIntegral(Function function, Interval interval) {
            Integral integral = new Integral(function, interval);
            return integral.integrate();
        }
    }
}
