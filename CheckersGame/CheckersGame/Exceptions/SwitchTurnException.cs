using System;

namespace CheckersGame.Exceptions
{
    public class SwitchTurnException : Exception
    {
        public SwitchTurnException() : base() { }
        public SwitchTurnException(string message) : base(message) { }
    }
}
