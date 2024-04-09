using System;

namespace CheckersGame.Exceptions
{
    public class InvalidPositionException : Exception
    {
        public InvalidPositionException() : base() { }
        public InvalidPositionException(string message) : base(message) { }
    }
}
