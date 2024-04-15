using System;

namespace CheckersGame.Exceptions
{
    public class GameOverException : Exception
    {
        public GameOverException() : base() { }
        public GameOverException(string message) : base(message) { }
    }
}
