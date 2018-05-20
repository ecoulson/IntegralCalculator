using System;
namespace IntegralCalculator
{
    public class UnknownSymbolException: Exception
    {
        public UnknownSymbolException() {
        }

        public UnknownSymbolException(string message): base(message) {
        }

        public UnknownSymbolException(string message, Exception inner): base(message, inner) {
        }

    }
}
