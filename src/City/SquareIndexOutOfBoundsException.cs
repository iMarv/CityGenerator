using System;

namespace City
{
    internal class SquareIndexOutOfBoundsException : Exception
    {
        public SquareIndexOutOfBoundsException()
        {
        }

        public SquareIndexOutOfBoundsException(string message) : base(message)
        {
        }

        public SquareIndexOutOfBoundsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}