using System;
namespace IntegralCalculator.Exceptions
{
    public class IllegalSeekException : Exception
    {
        public IllegalSeekException() {
        }

        public IllegalSeekException(string message) : base(message) {
        }

        public IllegalSeekException(string message, Exception inner): base(message, inner) {
        }
    }
}
