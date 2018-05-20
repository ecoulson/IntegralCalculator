using System;
namespace IntegralCalculator.Exceptions
{
    public class IllegalTermException : Exception
    {
        public IllegalTermException() {
        }

        public IllegalTermException(string message) : base(message) {
        }

        public IllegalTermException(string message, Exception inner): base(message, inner) {
        }
    }
}
