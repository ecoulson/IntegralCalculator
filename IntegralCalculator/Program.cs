using System;
using IntegralCalculator.App;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace IntegralCalculator
{
    class MainClass
    {
        private static Calculator calculator;
        private static List<Function> functions;
        private static Interval sampleInterval;
        private static Function currentFunction;

        private static int INTERVAL_SIZE = 5;
        private static int SAMPLE_COUNT = 30;
        private static string[] functionExpressions;
        private static string sameIntervalOutput = "";
        private static string differentIntervalOuput = "";
        private static int currentSample = 0;
        private static int currentFunctionNumber = 1;

        public static void Main(string[] args) {
            calculator = new Calculator();
            functionExpressions = getFunctionExpressions();
            functions = createFunctions();
            while (isSampling()) {
                takeSample();
            }
            writeFiles();
        }

        private static string[] getFunctionExpressions() {
            string text = File.ReadAllText(@"/Users/evancoulson/IntegralCalculator/functions.txt").Trim();
            return text.Split('\n');
        }

        private static List<Function> createFunctions() {
            List<Function> functions = new List<Function>();
            for (int i = 0; i < functionExpressions.Length; i++) {
                Function function = new Function(functionExpressions[i]);
                functions.Add(function);
            }
            return functions;
        }

        private static bool isSampling() {
            return currentSample < SAMPLE_COUNT;
        }

        private static void takeSample() {
            incrementSample();
            currentFunctionNumber = 0;
            sampleInterval = Interval.generateRandomInterval(INTERVAL_SIZE);
            foreach (Function function in functions) {
                integrateFunction(function);
            }
            printSamplingProgess();
            appendLine();
        }

        private static void incrementSample() {
            currentSample++;
        }

        private static void integrateFunction(Function function) {
            incrementFunctionNumber();
            currentFunction = function;
            appendDifferentIntervalOuput();
            appendSameIntervalOuput();
            printIntegralProgess();
        }

        private static void incrementFunctionNumber() {
            currentFunctionNumber++;
        }

        private static void appendDifferentIntervalOuput() {
            Interval interval = Interval.generateRandomInterval(INTERVAL_SIZE);
            double result = calculator.calculateDefiniteIntegral(currentFunction, interval);
            differentIntervalOuput += getFormatedOutputLine(interval, result);
        }

        private static void appendSameIntervalOuput() {
            double result = calculator.calculateDefiniteIntegral(currentFunction, sampleInterval);
            sameIntervalOutput += getFormatedOutputLine(result);
        }

        private static string getFormatedOutputLine(double result) {
            return getFormatedOutputLine(sampleInterval, result);
        }

        private static string getFormatedOutputLine(Interval interval, double result) {
            double start = interval.getStartPoint();
            double end = interval.getEndPoint();
            return string.Format(" function: {0,-40} interval: ({1,-16}, {2,-16}) result: {3,-16}\n", 
                functionExpressions[currentFunctionNumber - 1], start, end, result.ToString("E10"));
        }

        private static void printIntegralProgess() {
            Console.WriteLine(currentFunctionNumber + " / {0} integrals taken...", functions.Count);
        }

        private static void printSamplingProgess() {
            Console.WriteLine(currentSample + " / {0} samples taken...", SAMPLE_COUNT);
        }

        private static void appendLine() {
            sameIntervalOutput += "\n";
            differentIntervalOuput += "\n";
        }

        private static void writeFiles() {
            File.WriteAllText(@"/Users/evancoulson/IntegralCalculator/functions_out_same_interval.txt", sameIntervalOutput);
            File.WriteAllText(@"/Users/evancoulson/IntegralCalculator/functions_out_diff_interval.txt", differentIntervalOuput);
        }
    }
}
