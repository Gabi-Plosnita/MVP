using System;

namespace CheckersGame.Exceptions
{
    public class InvalidMoveException : Exception
    {
        public InvalidMoveException() : base() { }
        public InvalidMoveException(string message) : base(message) { }
    }
}
