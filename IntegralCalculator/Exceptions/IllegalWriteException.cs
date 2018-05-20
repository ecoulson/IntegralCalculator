using System;
namespace IntegralCalculator.Exceptions
{
    public class IllegalWriteException : Exception
    {
        public IllegalWriteException() {
        }

        public IllegalWriteException(string message) : base(message) {
        }

        public IllegalWriteException(string message, Exception inner): base(message, inner) {
        }
    }
}
