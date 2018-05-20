using System;

using IntegralCalculator.App;

namespace IntegralCalculator
{
    class MainClass
    {
        public static void Main(string[] args) {
            CalculatorClient client = new CalculatorClient();
            client.run();
        }
    }
}
