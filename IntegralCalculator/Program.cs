using System;

using IntegralCalculator.App;

namespace IntegralCalculator
{
    class MainClass
    {
        public static void Main(string[] args) {
            Calculator calculator = new Calculator();
            Function function = new Function("f(x)= arcsin(x)");
            Interval interval = new Interval(0, 1);
            double n = calculator.calculateDefiniteIntegral(function, interval);
            Console.WriteLine(n);
            //CalculatorClient client = new CalculatorClient();
            //client.run();
        }
    }
}
