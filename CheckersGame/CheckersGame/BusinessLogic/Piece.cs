﻿using CheckersGame.DataAccess;
using CheckersGame.Exceptions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CheckersGame.BusinessLogic
{
    public class Piece : BaseNotification
    {

        private EType pieceType;
        public EType PieceType
        {
            get { return pieceType; }
            set
            {
                pieceType = value;
                SetImagePath();
                NotifyPropertyChanged();
            }
        }

        private EColor pieceColor;
        public EColor PieceColor
        {
            get { return pieceColor; }
        }

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

        public Piece(EType type, EColor color)
        {
            pieceType = type;
            pieceColor = color;
            SetImagePath();
        }

        private void SetImagePath()
        {
            if (pieceType == EType.NormalPiece)
            {
                if (pieceColor == EColor.Black)
                {
                    ImagePath = ".\\..\\..\\Resources\\BlackPiece.png";
                }
                else
                {
                    ImagePath = ".\\..\\..\\Resources\\RedPiece.png";
                }
            }
            else if (pieceType == EType.QueenPiece)
            {
                if (pieceColor == EColor.Black)
                {
                    ImagePath = ".\\..\\..\\Resources\\BlackQueen.png";
                }
                else
                {
                    ImagePath = ".\\..\\..\\Resources\\RedQueen.png";
                }
            }
            else
            {
                ImagePath = "";
            }
        }

        public List<Position> GetPossibleMoves(Position piecePosition, 
            ObservableCollection<ObservableCollection<Piece>> board)
        {
            int row = piecePosition.Row;
            int col = piecePosition.Col;

            if (!UtilityBoard.IsPositionInBoard(piecePosition, board.Count, board[0].Count))
            {
                throw new InvalidPositionException($"Position {piecePosition.ToString()} is not in board!");
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
                        if (possibleCol % 2 != 0 && possibleRow % 2 != 0) // Simple Move
                        {
                            if (board[row + possibleRow][col + possibleCol].PieceType == EType.None)
                            {
                                possibleMoves.Add(possiblePosition);
                            }
                        }
                        else if (possibleCol % 2 == 0 && possibleRow % 2 == 0) // Jump Move
                        {
                            if (board[row + possibleRow / 2][col + possibleCol / 2].PieceColor != pieceColor
                                && board[row + possibleRow / 2][col + possibleCol / 2].PieceColor != EColor.None
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
