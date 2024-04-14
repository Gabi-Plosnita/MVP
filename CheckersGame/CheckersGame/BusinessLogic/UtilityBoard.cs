namespace CheckersGame.BusinessLogic
{
    public static class UtilityBoard
    {
        static public bool IsPositionInBoard(Position position, int nrRows, int nrCols)
        {
            return position.Row >= 0 && position.Row < nrRows && position.Col >= 0 && position.Col < nrCols;
        }
    }
}
