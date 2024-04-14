using System;

namespace CheckersGame.Exceptions
{
    public class NoMovesException : Exception
    {
        public NoMovesException() : base() { }
        public NoMovesException(string message) : base(message) { }
    }
}
