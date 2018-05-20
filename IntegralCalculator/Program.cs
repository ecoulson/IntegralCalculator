using System;

using IntegralCalculator.App;

namespace IntegralCalculator
{
    class MainClass
    {
        public static void Main(string[] args) {
            Calculator calculator = new Calculator();
            Function function = new Function("f(x)=e");
            Interval interval = new Interval(0, 5);
            double n = calculator.calculateDefiniteIntegral(function, interval);
            Console.WriteLine(n);
        }
    }
}
