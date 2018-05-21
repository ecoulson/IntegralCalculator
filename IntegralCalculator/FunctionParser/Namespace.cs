using System;
using System.Collections.Generic;
using IntegralCalculator.App;

namespace IntegralCalculator.FunctionParser
{
    public class Namespace
    {
        private Dictionary<string, Function> functionNameSpace;
        private Dictionary<string, string> constantNameSpace;

        public Namespace() {
            this.functionNameSpace = new Dictionary<string, Function>();
            this.constantNameSpace = new Dictionary<string, string>();
        }

        public void addConstant(string constant, string value) {
            constantNameSpace.Add(constant, value);
        }

        public void addFunction(string name, Function function) {
            functionNameSpace.Add(name, function);
        }

        public bool hasFunction(string functionName) {
            return functionNameSpace.ContainsKey(functionName);
        }

        public bool hasConstant(string constantName) {
            return constantNameSpace.ContainsKey(constantName);
        }

        public Function getFunction(string functionName) {
            return functionNameSpace[functionName];
        }

        public string getConstant(string constant) {
            return constantNameSpace[constant];
        }
    }
}
