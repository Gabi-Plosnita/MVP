using CheckersGame.BusinessLogic;
using CheckersGame.Commands;
using CheckersGame.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CheckersGame.ViewModel
{
    public class MainViewModel : BaseNotification
    {
        private Game Game = new Game();
        public ObservableCollection<Square> Board { get; private set; }

        private Square selectedSquare = null;

        private List<Position> highlightedMoves = new List<Position>();

        private string turnMessage;
        public string TurnMessage
        {
            get { return turnMessage; }
            set
            {
                turnMessage = value;
                NotifyPropertyChanged();
            }
        }

        private string statusMessage;

        public string StatusMessage
        {
            get { return statusMessage; }
            set
            {
                statusMessage = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
            InitializeBoard();
            TurnMessage = $"Turn: {Game.Turn.ToString()}";
            SquareClickCommand = new RelayCommand<Square>(SquareClick);
            SwitchTurnCommand = new RelayCommand<Object>(SwitchTurnClick);
        }

        private void InitializeBoard()
        {
            Board = new ObservableCollection<Square>();

            for (int i = 0; i < Game.Board.Count; i++)
            {
                for (int j = 0; j < Game.Board[i].Count; j++)
                {
                    Square square = new Square();
                    if( (i + j) % 2 != 0)
                    {
                        square.BackgroundImagePath = ".\\..\\..\\Resources\\bg1.png";
                    }
                    else
                    {
                        square.BackgroundImagePath = ".\\..\\..\\Resources\\bg2.jpg";
                    }
                    square.Position = new Position(i, j);
                    square.Piece = Game.Board[i][j];
                    Board.Add(square);
                }
            }
        }

        private void UpdateBoard()
        {
            for (int i = 0; i < Game.Board.Count; i++)
            {
                for (int j = 0; j < Game.Board[i].Count; j++)
                {
                    //Board[i * 8 + j].Piece = Game.Board[i][j];
                    Board[i * 8 + j] = new Square
                    {
                        Piece = Game.Board[i][j],
                        Position = new Position(i, j),
                        BackgroundImagePath = Board[i * 8 + j].BackgroundImagePath
                    };
                }
            }
        }

        private void HighlightMoves(Position position)
        {
            try
            {
                highlightedMoves = Game.GetMoves(position);
                foreach (Position move in highlightedMoves)
                {
                    Board[move.Row * 8 + move.Col].BackgroundImagePath = ".\\..\\..\\Resources\\highlight.png";
                }
            }
            catch (Exception e)
            {
                StatusMessage = e.Message;
            }
        }

        private void UnHighlightMoves()
        {
            foreach(Position move in highlightedMoves)
            {
                string backgroundPath;
                if((move.Row + move.Col) % 2 != 0)
                {
                    backgroundPath = ".\\..\\..\\Resources\\bg1.png";
                }
                else
                {
                    backgroundPath = ".\\..\\..\\Resources\\bg2.jpg";
                }
                Board[move.Row * 8 + move.Col].BackgroundImagePath = backgroundPath;
            }
        }

        public ICommand SquareClickCommand { get; private set; }

        private void SquareClick(Square square)
        {
            StatusMessage = "";
            if (selectedSquare == null)
            {
                if(square.Piece.PieceColor == Game.Turn)
                {
                    selectedSquare = square;
                    HighlightMoves(square.Position);
                }
                else
                {
                    StatusMessage = "Invalid square!";
                }
            }
            else
            {
                if(selectedSquare == square)
                {
                    selectedSquare = null;
                    UnHighlightMoves();
                }
                else
                {
                    try
                    {
                        Game.MakeMove(selectedSquare.Position, square.Position);
                        UnHighlightMoves();
                        UpdateBoard();
                    }
                    catch (Exception ex)
                    {
                        if (square.Piece.PieceColor == Game.Turn)
                        {
                            selectedSquare = square;
                            UnHighlightMoves();
                            HighlightMoves(square.Position);
                        }
                        else
                        {
                            UnHighlightMoves();
                            selectedSquare = null;
                            StatusMessage = ex.Message;
                        }                    
                    }
                }
            }
        }

        public ICommand SwitchTurnCommand { get; private set; }

        private void SwitchTurnClick(Object param)
        {
            try
            {
                Game.SwitchTurn();
                TurnMessage = $"Turn: {Game.Turn.ToString()}";
                StatusMessage = "";
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
            }
        }
    }
}
