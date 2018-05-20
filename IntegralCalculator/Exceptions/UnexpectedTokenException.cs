using System;
namespace IntegralCalculator.Exceptions
{
    public class UnexpectedTokenException:Exception
    {
        public UnexpectedTokenException() {
        }

        public UnexpectedTokenException(string message): base(message) {
        }

        public UnexpectedTokenException(string message, Exception inner): base(message, inner) {
        }
    }
}
