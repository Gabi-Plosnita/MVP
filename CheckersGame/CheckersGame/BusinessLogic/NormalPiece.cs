using System.Collections.Generic;
using CheckersGame.DataAccess;
using CheckersGame.Exceptions;

namespace CheckersGame.BusinessLogic
{
    public class NormalPiece : Piece
    {
        public NormalPiece(EColor color) : base(EType.NormalPiece, color)
        {
        }
        public override List<Position> GetPossibleMoves(Position piecePosition, Piece[,] board)
        {
            int row = piecePosition.Row;
            int col = piecePosition.Col;

            if(!UtilityBoard.IsPositionInBoard(piecePosition, board.GetLength(0), board.GetLength(1)))
            {
                throw new InvalidPositionException($"Position({row},{col}) is not in board!");
            }

            List<Position> possibleMoves = new List<Position>();

            int[] possibleCols = { -1, 1 , -2, 2 };
            int[] possibleRows;

            if(pieceColor == EColor.Black)
            {
                possibleRows = new int[] { 1, 2 };
            }
            else
            {
                possibleRows = new int[] { -1, -2 };
            }  

            foreach(int possibleCol in possibleCols)
            {
                foreach (int possibleRow in possibleRows)
                {
                    Position possiblePosition = new Position(row + possibleRow, col + possibleCol);
                    if (UtilityBoard.IsPositionInBoard(possiblePosition, board.GetLength(0), board.GetLength(1)))
                    {
                        if (possibleCol % 2 == 1 && possibleRow % 2 == 1) // Simple Move
                        {
                            if (board[row + possibleRow, col + possibleCol].PieceType == EType.None)
                            {
                                possibleMoves.Add(possiblePosition);
                            }
                        }
                        else if (possibleCol % 2 == 0 && possibleRow % 2 == 0) // Jump Move
                        {
                            if (board[row + possibleRow / 2, col + possibleCol / 2].PieceColor != pieceColor
                                && board[row + possibleRow, col + possibleCol].PieceType == EType.None)
                            {
                                possibleMoves.Add(possiblePosition);
                            }
                        }
                    }
                }
            }
            return possibleMoves;
        }
    }
}
