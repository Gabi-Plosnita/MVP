﻿using CheckersGame.DataAccess;
using CheckersGame.Exceptions;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CheckersGame.BusinessLogic
{
    public class Game
    {
        private ObservableCollection<ObservableCollection<Piece>> board;
        public ObservableCollection<ObservableCollection<Piece>> Board
        {
            get { return board; }
            private set { board = value; }
        }

        private EColor turn;
        public EColor Turn
        {
            get { return turn; }
            private set { turn = value; }
        }

        public int RedPiecesNr;

        public int BlackPiecesNr;
        public bool pieceMoved { get; private set; }
        public bool pieceJumped { get; private set; }
        public Position positionJumped { get; set; }

        public bool AllowMultipleJumps { get; set; }

        public Game()
        {
            InitializeGame();
            AllowMultipleJumps = true;
        }

        private void InitializeBoard()
        {
            board = new ObservableCollection<ObservableCollection<Piece>>();
            for (int i = 0; i < 8; i++)
            {
                board.Add(new ObservableCollection<Piece>());
                for (int j = 0; j < 8; j++)
                {
                    if (i < 3 && (i + j) % 2 != 0)
                    {
                        board[i].Add(new Piece(EType.NormalPiece, EColor.Black));
                    }
                    else if (i > 4 && (i + j) % 2 != 0)
                    {
                        board[i].Add(new Piece(EType.NormalPiece, EColor.Red));
                    }
                    else
                    {
                        board[i].Add(new Piece(EType.None, EColor.None));
                    }
                }
            }
        }

        public void InitializeGame()
        {
            RedPiecesNr = 12;
            BlackPiecesNr = 12;
            pieceMoved = false;
            pieceJumped = false;
            turn = EColor.Red;
            positionJumped = new Position(-1, -1);
            InitializeBoard();
        }

        public void SwitchTurn()
        {
            if(IsGameOver())
            {
                throw new GameOverException("The game is over!");
            }
            if(!pieceMoved)
            {
                throw new SwitchTurnException("You must move a piece before switching turn!");
            }
            turn = turn == EColor.Black ? EColor.Red : EColor.Black;
            pieceMoved = false;
            pieceJumped = false;
            positionJumped = new Position(-1, -1);
        }

        public bool IsGameOver()
        {
            return RedPiecesNr == 0 || BlackPiecesNr == 0;
        }

        public List<Position> GetMoves(Position position)
        {
            if (IsGameOver())
            {
                throw new GameOverException("The game is over!");
            }

            if(pieceMoved && !pieceJumped)
            {
                throw new NoMovesException("You can't move this piece!");
            }

            if(pieceJumped && position != positionJumped)
            {
                throw new NoMovesException("You can't move this piece!");
            }

            if (!UtilityBoard.IsPositionInBoard(position, board.Count, board[0].Count))
            {
                throw new InvalidPositionException($"Position {position.ToString()} is invalid!");
            }

            Piece piece = board[position.Row][position.Col];

            List<Position> possibleMoves = piece.GetPossibleMoves(position, board);

            if (pieceJumped)
            {
                List<Position> possibleMovesCopy = new List<Position>(possibleMoves);
                foreach (Position move in possibleMovesCopy)
                {
                    if (Math.Abs(move.Row - position.Row) == 1)
                    {
                        possibleMoves.Remove(move);
                    }
                }
            }

            if(possibleMoves.Count == 0)
            {
                throw new NoMovesException("You can't move this piece!");
            }

            return possibleMoves;
        }

        public void MakeMove(Position startPos, Position endPos)
        {
            if (IsGameOver())
            {
                throw new GameOverException("The game is over!");
            }

            if (!UtilityBoard.IsPositionInBoard(startPos, board.Count, board[0].Count))
            {
                throw new InvalidPositionException($"Position {startPos.ToString()} is invalid!");
            }
            if (!UtilityBoard.IsPositionInBoard(endPos, board.Count, board[0].Count))
            {
                throw new InvalidPositionException($"Position {endPos.ToString()} is invalid!");
            }

            Piece piece = board[startPos.Row][startPos.Col];

            if (piece.PieceColor != turn)
            {
                throw new InvalidPieceColorException("This is not your piece!");
            }

            List<Position> possibleMoves = GetMoves(startPos);

            if (pieceJumped)
            {
                List<Position> possibleMovesCopy = new List<Position>(possibleMoves);
                foreach(Position move in possibleMovesCopy)
                {
                    if (Math.Abs(move.Row - startPos.Row) == 1)
                    {
                        possibleMoves.Remove(move);
                    }
                }
            }

            if (!possibleMoves.Contains(endPos))
            {
                throw new InvalidMoveException($"Invalid move from {startPos.ToString()} to {endPos.ToString()}");
            }

            board[endPos.Row][endPos.Col] = board[startPos.Row][startPos.Col];
            board[startPos.Row][startPos.Col] = new Piece(EType.None, EColor.None);
            pieceMoved = true;

            if (Math.Abs(startPos.Row - endPos.Row) == 2)
            {
                Position jumpedPiece = new Position((startPos.Row + endPos.Row) / 2, (startPos.Col + endPos.Col) / 2);
                board[jumpedPiece.Row][jumpedPiece.Col] = new Piece(EType.None, EColor.None);
                pieceJumped = true;
                positionJumped = endPos;

                if (turn == EColor.Black)
                {
                    RedPiecesNr--;
                }
                else
                {
                    BlackPiecesNr--;
                }
            }

            if (piece.PieceType == EType.NormalPiece)
            {
                if (endPos.Row == 0 || endPos.Row == 7)
                {
                    board[endPos.Row][endPos.Col].PieceType = EType.QueenPiece;
                }
            }

            if (!AllowMultipleJumps && !IsGameOver())
            {
                SwitchTurn();
            }
        }

        public void SaveToFile(string filePath)
        {
            // Serialize the Game object to JSON
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);

            // Write the JSON to the file
            File.WriteAllText(filePath, json);
        }

        public void LoadFromFile(string filePath)
        {
            // Read the JSON from the file
            string json = File.ReadAllText(filePath);

            // Deserialize the JSON to a JObject
            JObject jsonObject = JObject.Parse(json);

            // Initialize properties based on the JSON data
            this.RedPiecesNr = (int)jsonObject["RedPiecesNr"];
            this.BlackPiecesNr = (int)jsonObject["BlackPiecesNr"];
            this.Turn = (EColor)(int)jsonObject["Turn"];
            this.AllowMultipleJumps = (bool)jsonObject["AllowMultipleJumps"];
            this.pieceMoved = (bool)jsonObject["pieceMoved"];
            this.pieceJumped = (bool)jsonObject["pieceJumped"];
            this.positionJumped = new Position((int)jsonObject["positionJumped"]["Row"], (int)jsonObject["positionJumped"]["Col"]);

            // Initialize the Board property
            this.Board = new ObservableCollection<ObservableCollection<Piece>>();
            JArray boardArray = (JArray)jsonObject["Board"];
            foreach (JArray rowArray in boardArray)
            {
                ObservableCollection<Piece> row = new ObservableCollection<Piece>();
                foreach (JObject pieceObject in rowArray)
                {
                    var pieceType = (EType)(int)pieceObject["PieceType"];
                    var pieceColor = (EColor)(int)pieceObject["PieceColor"];
                    Piece piece = new Piece(pieceType, pieceColor);
                    row.Add(piece);
                }
                this.Board.Add(row);
            }
        }
    }
}
