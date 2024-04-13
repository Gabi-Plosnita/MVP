using CheckersGame.DataAccess;
using CheckersGame.Exceptions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CheckersGame.BusinessLogic
{
    public class Piece : BaseNotification
    {

        private EType pieceType;

        private EColor pieceColor;

        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                NotifyPropertyChanged();
            }
        }

        protected Piece(EType type, EColor color)
        {
            pieceType = type;
            pieceColor = color;
        }

        public EType PieceType
        {
            get { return pieceType; }
            set
            {
                pieceType = value;
                NotifyPropertyChanged();
            }
        }

        public EColor PieceColor
        {
            get { return pieceColor; }
        }

        public List<Position> GetPossibleMoves(Position piecePosition, 
            List<List<Piece>> board)
        {
            int row = piecePosition.Row;
            int col = piecePosition.Col;

            if (!UtilityBoard.IsPositionInBoard(piecePosition, board.Count, board[0].Count))
            {
                throw new InvalidPositionException($"Position({row},{col}) is not in board!");
            }

            List<Position> possibleMoves = new List<Position>();

            int[] possibleCols = { -1, 1, -2, 2 };
            int[] possibleRows;

            if(pieceType == EType.NormalPiece)
            {
                if (pieceColor == EColor.Black)
                {
                    possibleRows = new int[] { 1, 2 };
                }
                else
                {
                    possibleRows = new int[] { -1, -2 };
                }
            }
            else
            {
                possibleRows = new int[] { -1, 1, -2, 2 };
            }
            
            foreach (int possibleCol in possibleCols)
            {
                foreach (int possibleRow in possibleRows)
                {
                    Position possiblePosition = new Position(row + possibleRow, col + possibleCol);
                    if (UtilityBoard.IsPositionInBoard(possiblePosition, board.Count, board[0].Count))
                    {
                        if (possibleCol % 2 == 1 && possibleRow % 2 == 1) // Simple Move
                        {
                            if (board[row + possibleRow][col + possibleCol].PieceType == EType.None)
                            {
                                possibleMoves.Add(possiblePosition);
                            }
                        }
                        else if (possibleCol % 2 == 0 && possibleRow % 2 == 0) // Jump Move
                        {
                            if (board[row + possibleRow / 2][col + possibleCol / 2].PieceColor != pieceColor
                                && board[row + possibleRow][col + possibleCol].PieceType == EType.None)
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
