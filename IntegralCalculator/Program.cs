using System;

namespace IntegralCalculator
{
    class MainClass
    {
        public static void Main(string[] args) {
            IntegralCalculator calculator = new IntegralCalculator();
            Function function = new Function("x^2 + 2x + 1");
            Interval interval = new Interval(0, 5);
            double n = calculator.calculateDefiniteIntegral(function, interval);
            Console.WriteLine(n);
        }
    }
}
