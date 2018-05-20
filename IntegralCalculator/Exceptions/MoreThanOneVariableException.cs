using System;
namespace IntegralCalculator.Exceptions
{
    public class MoreThanOneVariableException : Exception
    {
        public MoreThanOneVariableException()
        {
        }

        public MoreThanOneVariableException(string message) : base(message) {
        }

        public MoreThanOneVariableException(string message, Exception inner): base(message, inner) {
        }
    }
}
