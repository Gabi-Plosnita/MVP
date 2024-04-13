using System;

namespace CheckersGame.Exceptions
{
    public class InvalidPieceColorException : Exception
    {
        public InvalidPieceColorException() : base() { }
        public InvalidPieceColorException(string message) : base(message) { }
    }
}
