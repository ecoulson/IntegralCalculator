using System;
namespace IntegralCalculator.Exceptions
{
    public class UnknownVariableException : Exception
    {
        public UnknownVariableException() {
        }

        public UnknownVariableException(string message): base(message) {
        }

        public UnknownVariableException(string message, Exception inner): base(message, inner) {
        }
    }
}
