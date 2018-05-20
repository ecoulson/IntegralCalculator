using System;
namespace IntegralCalculator
{
    public class UnknownTokenException: Exception
    {
        public UnknownTokenException() {
        }

        public UnknownTokenException(string message): base(message) {
        }

        public UnknownTokenException(string message, Exception inner): base(message, inner) {
        }
    }
}
