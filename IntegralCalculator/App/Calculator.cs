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
    }
}
