using System;
namespace IntegralCalculator.FunctionParser
{
    public class Symbol
    {
        private string symbol;

        public Symbol(string symbol) {
            if (symbol.Length == 0) {
                throw new IllegalSymbolLengthException("Symbol Length Must Be Greater Than 0");
            }
            this.symbol = symbol;
        }

        public string getValue() {
            return symbol;
        }
    }
}
