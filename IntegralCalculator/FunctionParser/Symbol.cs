using System;
namespace IntegralCalculator.FunctionParser
{
    public class Symbol
    {
        private string symbol;

        public Symbol(string symbol) {
            if (!isValid(symbol)) {
                throw new IllegalSymbolLengthException("Symbol Length Must Be Greater Than 0");
            }
            this.symbol = symbol;
        }

        private bool isValid(string newSymbol) {
            return newSymbol.Length != 0;
        }

        public string getValue() {
            return symbol;
        }

        public void setSymbol(string newSymbol) {
            if (!isValid(newSymbol)) {
                throw new IllegalSymbolLengthException("Symbol Length Must Be Greater Than 0");
            }
            this.symbol = newSymbol;
        }
    }
}
