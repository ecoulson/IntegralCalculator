using System;
namespace IntegralCalculator
{
    public class IllegalSymbolLengthException : Exception
    {
        public IllegalSymbolLengthException() {
        }

        public IllegalSymbolLengthException(string message) : base(message) {
        }

        public IllegalSymbolLengthException(string message,  Exception inner): base(message, inner) { 
        }
    }
}
