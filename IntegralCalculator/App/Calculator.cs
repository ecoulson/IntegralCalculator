using System;
using IntegralCalculator.FunctionParser;

namespace IntegralCalculator.App
{
    public class Calculator
    {
        public static Namespace globalNameSpace = new Namespace();
        public static Namespace currentNameSpace = new Namespace();

        public Calculator() {
            PredefinedFunctions.addFunctionsToGlobalSpace();
        }

        public double calculateDefiniteIntegral(Function function, Interval interval) {
            Integral integral = new Integral(function, interval);
            return integral.integrate();
        }

        public Interval getRandomInterval(Function function, double length) {
            Interval interval = Interval.generateRandomInterval(length);
            double n = calculateDefiniteIntegral(function, interval);
            while (isUndefined(n)) {
                interval = Interval.generateRandomInterval(length);
                n = calculateDefiniteIntegral(function, interval);
            }
            return interval;
        }

        private bool isUndefined(double n) {
            return double.IsNaN(n) || double.IsInfinity(n);
        }
    }
}
