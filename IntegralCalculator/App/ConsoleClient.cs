using System;
namespace IntegralCalculator.App
{
    public class ConsoleClient
    {
        private Calculator calculator;

        public ConsoleClient(Calculator calculator) {
            this.calculator = calculator;
        }

        public void handleConsoleInput() {
            Function function = readFunction();
            if (function == null) {
                handleIllegalAction();
                return;
            }

            Interval interval = readInterval();
            if (interval == null) {
                handleIllegalAction();
                return;
            }

            double n = calculator.calculateDefiniteIntegral(function, interval);
            Console.WriteLine(n);
            Console.WriteLine("Press any key to finish calculation...");
            Console.ReadKey();
        }

        private Function readFunction() {
            Console.WriteLine("Enter a function");
            string expression = Console.ReadLine();
            return parseFunction(expression);
        }

        private Function parseFunction(string expression) {
            try {
                Function function = new Function(expression);
                return function;
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine("Illegal Function Inputed");
                return null;
            }
        }

        private void handleIllegalAction() {
            Console.WriteLine("Press any key to resume...");
            Console.ReadKey();
        }

        private Interval readInterval() {
            Console.WriteLine("Enter an Interval");
            string intervalInput = Console.ReadLine();
            return parseInterval(intervalInput);
        }

        private Interval parseInterval(string intervalInput) {
            try {
                //TODO: should parse expressions
                double start = parseStart(intervalInput);
                double end = parseEnd(intervalInput);
                return new Interval(start, end);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private double parseStart(string intervalInput) {
            string start = "";
            for (int i = 0; i < intervalInput.Length; i++) {
                if (isDigit(intervalInput[i])) {
                    start += intervalInput[i];
                } else {
                    return double.Parse(start);
                }
            }
            throw new Exception("Only found a start value for the inputed interval");
        }

        private double parseEnd(string intervalInput) {
            string end = "";
            for (int i = intervalInput.Length - 1; i >= 0; i--) {
                if (isDigit(intervalInput[i])) {
                    end = intervalInput[i] + end;
                } else {
                    return double.Parse(end);
                }
            }
            throw new Exception("Only found an end value for the inputed interval");
        }

        private bool isDigit(char ch) {
            return ch == '-' || ch == '.' || char.IsDigit(ch);
        }
    }
}
