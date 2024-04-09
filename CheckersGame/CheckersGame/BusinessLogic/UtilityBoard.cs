namespace CheckersGame.BusinessLogic
{
    public static class UtilityBoard
    {
        static public bool IsPositionInBoard(Position position, int nrRows, int nrCols)
        {
            return position.Row >= nrRows && position.Row < nrRows && position.Col >= nrCols && position.Col < nrCols;
        }
    }
}
