using System;
using IntegralCalculator.App;
using System.IO;

namespace IntegralCalculator
{
    class MainClass
    {
        private static int INTERVAL_SIZE = 50;

        public static void Main(string[] args) {
            Calculator calculator = new Calculator();
            string text = File.ReadAllText(@"/Users/evancoulson/IntegralCalculator/functions.txt").Trim();
            string[] functionExpressions = text.Split('\n');
            string result = "";
            for (int i = 0; i < functionExpressions.Length; i++) {
                Function function = new Function(functionExpressions[i]);
                Interval interval = Interval.generateRandomInterval(INTERVAL_SIZE);
                double n = calculator.calculateDefiniteIntegral(function, interval);
                string line = string.Format("function: {0,-40} interval: ({1,-16}, {2,-16}) result: {3,-16}\n", functionExpressions[i], interval.getStartPoint(), interval.getEndPoint(), n);
                result += line;
                Console.WriteLine((i + 1) + " / 30 integrals taken...");
            }
            File.WriteAllText(@"/Users/evancoulson/IntegralCalculator/functions_out.txt", result);
            //CalculatorClient client = new CalculatorClient();
            //client.run();
        }
    }
}
