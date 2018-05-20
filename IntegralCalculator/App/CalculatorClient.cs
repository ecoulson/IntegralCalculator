using System;
namespace IntegralCalculator.App
{
    public class CalculatorClient
    {
        private bool running;

        public CalculatorClient() {
            this.running = true;
            Calculator calculator = new Calculator();
            Function function = new Function("f(x)=2.1eeeex + 2sin(x)");
            Interval interval = new Interval(0, 5);
            double n = calculator.calculateDefiniteIntegral(function, interval);
            Console.WriteLine(n);
        }

        public void run() {
            while (isRunning()) {
                printMenu();
                handleOption();
                Console.Clear();
            }
        }

        private bool isRunning() {
            return running;
        }

        private void printMenu() {
            Console.WriteLine("Definite Integral Calculator by ecoulson");
            Console.WriteLine("Press the listed key and press return to select an option");
            Console.WriteLine("[1] Read User Input");
            Console.WriteLine("[2] Read File");
        }

        private void handleOption() {
            char key = readKey();
            switch (key) {
                case '1':
                    handleConsoleInput();
                    break;
                case '2':
                    handleFileInput();
                    break;
            }
        }

        private char readKey() {
            ConsoleKeyInfo input = Console.ReadKey();
            return input.KeyChar;
        }

        private void handleConsoleInput() {
            
        }

        private void handleFileInput() {
            throw new NotImplementedException();
        }
    }
}
