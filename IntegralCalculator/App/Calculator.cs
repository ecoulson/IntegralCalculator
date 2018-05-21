using System;
using System.Collections.Generic;

namespace IntegralCalculator.App
{
    public class Calculator
    {
        public static Dictionary<String, Function> functionNameSpace = new Dictionary<string, Function>();

        public Calculator() {
            functionNameSpace.Add("g", new Function("g(x)=x"));
        }

        public double calculateDefiniteIntegral(Function function, Interval interval) {
            Integral integral = new Integral(function, interval);
            return integral.integrate();
        }
    }
}
