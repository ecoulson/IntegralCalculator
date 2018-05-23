using System;

using IntegralCalculator.App;

namespace IntegralCalculator
{
    class MainClass
    {
        public static void Main(string[] args) {
            Calculator calculator = new Calculator();
            Function function = new Function("f(x)=(x^2+3*sin(x)+7)/(x^2+2)");
            Interval interval = new Interval(0,5);
            double n = calculator.calculateDefiniteIntegral(function, interval);
            Console.WriteLine(n);
            //CalculatorClient client = new CalculatorClient();
            //client.run();
        }
    }
}
