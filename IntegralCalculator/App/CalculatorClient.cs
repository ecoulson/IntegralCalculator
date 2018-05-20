using System;
namespace IntegralCalculator.App
{
    public class CalculatorClient
    {
        private Calculator calculator;
        private ConsoleClient consoleClient;
        private FileClient fileClient;
        private bool running;

        public CalculatorClient() {
            this.running = true;
            this.calculator = new Calculator();
            this.consoleClient = new ConsoleClient(calculator);
            this.fileClient = new FileClient(calculator);
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
                    consoleClient.handleConsoleInput();
                    break;
                case '2':
                    fileClient.handleFileInput();
                    break;
            }
        }

        private char readKey() {
            ConsoleKeyInfo input = Console.ReadKey();
            Console.WriteLine();
            return input.KeyChar;
        }


        private void handleFileInput() {
            throw new NotImplementedException();
        }
    }
}
