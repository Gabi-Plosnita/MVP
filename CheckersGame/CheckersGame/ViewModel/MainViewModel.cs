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

        private string allowJumpsMessage;

        public string AllowJumpsMessage
        {
            get { return allowJumpsMessage; }
            set
            {
                allowJumpsMessage = value;
                NotifyPropertyChanged();
            }
        }
        public bool AllowMultipleJumps
        {
            get
            {
                return Game.AllowMultipleJumps;
            }
            set
            {
                Game.AllowMultipleJumps = value;
                if (value)
                {
                    AllowJumpsMessage = "Disable multiple jumps";
                }
                else
                {
                    AllowJumpsMessage = "Allow multiple jumps";
                }
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
            InitializeBoard();
            TurnMessage = $"Turn: {Game.Turn.ToString()}";
            AllowJumpsMessage = "Disable multiple jumps";
            SquareClickCommand = new RelayCommand<Square>(SquareClick);
            SwitchTurnCommand = new RelayCommand<Object>(SwitchTurnClick);
            RestartGameCommand = new RelayCommand<Object>(RestartGameClick);
            ManageJumpsCommnd = new RelayCommand<Object>(ManageJumpsClick);
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
                selectedSquare = null;
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
                        selectedSquare = null;
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

        public ICommand RestartGameCommand { get; private set; }

        public void RestartGameClick(Object param)
        {
            Game.InitializeGame();
            UpdateBoard();
            TurnMessage = $"Turn: {Game.Turn.ToString()}";
            StatusMessage = "";
        }

        public ICommand ManageJumpsCommnd { get; private set; }

        public void ManageJumpsClick(Object param)
        {
            AllowMultipleJumps = !AllowMultipleJumps;
        }
    }
}
