using System;
namespace IntegralCalculator.Exceptions
{
    public class IllegalDeclarationException : Exception
    {
        public IllegalDeclarationException() {
        }

        public IllegalDeclarationException(string message) : base(message) {
        }

        public IllegalDeclarationException(string message, Exception inner): base(message, inner) {
        }
    }
}
