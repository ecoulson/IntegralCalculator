using System;
namespace IntegralCalculator.Exceptions
{
    public class IllegalReadException : Exception
    {
        public IllegalReadException(){
        }

        public IllegalReadException(string message) : base(message) {
        }

        public IllegalReadException(string message, Exception inner): base(message, inner) {
        }
    }
}
