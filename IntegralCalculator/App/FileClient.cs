using System;
using System.IO;

namespace IntegralCalculator.App
{
    public class FileClient
    {
        private Calculator calculator;

        public FileClient(Calculator calculator) {
            this.calculator = calculator;
        }

        public void handleFileInput() {
            try {
                readFile();
            } catch (Exception e) {
                handleFileInputError(e);
            }
        }

        private void readFile() {
            Console.WriteLine("Enter file name");
            string fileName = readFileName();
            string fileData = getFileContent(fileName);
            parseIntegrals(fileData);
        }

        private string readFileName() {
            string fileName = Console.ReadLine();
            return removeExtension(fileName) + ".txt";
        }

        private string removeExtension(string fileName) {
            return fileName.Split('.')[0];
        }

        private string getFileContent(string fileName) {
            string path = @"/Users/evancoulson/IntegralCalculator/" + fileName;
            if (File.Exists(path)) {
                return File.ReadAllText(path);    
            } else {
                throw new Exception("Could not find file");
            }
        }

        private void parseIntegrals(string fileData) {
            string[] lines = fileData.Split('\n');
            for (int i = 0; i < lines.Length - 1; i++) {
                Console.Write("[" + (i + 1) + "]: ");
                calculateLine(lines[i]);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        private void calculateLine(string line) {
            string expression = readExpression(line);
            string intervalInput = readIntervalInput(line);
            Function function = parseFunction(expression);
            Interval interval = parseInterval(intervalInput);
            double result = calculator.calculateDefiniteIntegral(function, interval);
            Console.WriteLine(result);
        }

        private string readExpression(string line) {
            String[] parts = line.Split(',');
            return parts[0].Trim();
        }

        private string readIntervalInput(string line) {
            String[] parts = line.Split(',');
            parts[1] = parts[1].Trim();
            string intervalInput = parts[1].Substring(1, parts[1].Length - 2);
            return intervalInput;
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

        private void handleFileInputError(Exception e) {
            Console.WriteLine(e.Message);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
