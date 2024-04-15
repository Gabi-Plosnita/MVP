using CheckersGame.BusinessLogic;
using CheckersGame.Commands;
using CheckersGame.DataAccess;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace CheckersGame.ViewModel
{
    public class MainViewModel : BaseNotification
    {
        private Game Game = new Game();
        public ObservableCollection<Square> Board { get; private set; }

        private Square selectedSquare = null;

        private List<Position> highlightedMoves = new List<Position>();
        public StatisticsViewModel StatisticsViewModel { get; private set; }

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

        private bool gameJustStarted;
        public bool GameJustStarted
        {
            get
            {
                return gameJustStarted;
            }
            set
            {
                gameJustStarted = value;
                NotifyPropertyChanged();
            }
        }

        private string gameOverMessage;

        public string GameOverMessage
        {
            get { return gameOverMessage; }
            set
            {
                gameOverMessage = value;
                NotifyPropertyChanged();
            }
        }
        public MainViewModel()
        {
            StatisticsViewModel = new StatisticsViewModel();
            StatisticsViewModel.LoadStatistics();
            InitializeBoard();
            TurnMessage = $"Turn: {Game.Turn.ToString()}";
            AllowJumpsMessage = "Disable multiple jumps";
            GameJustStarted = true;

            SquareClickCommand = new RelayCommand<Square>(SquareClick);
            SwitchTurnCommand = new RelayCommand<Object>(SwitchTurnClick);
            RestartGameCommand = new RelayCommand<Object>(RestartGameClick);
            ManageJumpsCommnd = new RelayCommand<Object>(ManageJumpsClick);
            SaveGameCommand = new RelayCommand<Object>(SaveGameClick);
            LoadGameCommand = new RelayCommand<Object>(LoadGameClick);
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
                        if(Game.IsGameOver())
                        {
                            GameOverMessage = $"{Game.Turn.ToString()} wins!";
                            if(Game.Turn == EColor.Red)
                            {
                                StatisticsViewModel.RedWinsNumber++;
                                StatisticsViewModel.RedMaxPiecesNr = Math.Max(StatisticsViewModel.RedMaxPiecesNr, Game.RedPiecesNr);
                            }
                            else
                            {
                                StatisticsViewModel.BlackWinsNumber++;
                                StatisticsViewModel.BlackMaxPiecesNr = Math.Max(StatisticsViewModel.BlackMaxPiecesNr, Game.BlackPiecesNr);
                            }
                            StatisticsViewModel.SaveStatistics();
                        }
                        TurnMessage = $"Turn: {Game.Turn.ToString()}";
                        GameJustStarted = false;
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

        private void RestartGameClick(Object param)
        {
            Game.InitializeGame();
            UpdateBoard();
            selectedSquare = null;
            UnHighlightMoves();
            TurnMessage = $"Turn: {Game.Turn.ToString()}";
            StatusMessage = "";
            GameOverMessage = "";
            GameJustStarted = true;
        }

        public ICommand ManageJumpsCommnd { get; private set; }

        private void ManageJumpsClick(Object param)
        {
            AllowMultipleJumps = !AllowMultipleJumps;
        }

        public ICommand SaveGameCommand { get; private set; }

        private void SaveGameClick(Object param)
        {
            // Create a SaveFileDialog
            var saveFileDialog = new SaveFileDialog();

            // Set default file extension and filter
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";

            // Set the initial directory to the desired path
            string initialDirectory = Path.GetFullPath(".\\..\\..\\Resources\\GameFiles");
            saveFileDialog.InitialDirectory = initialDirectory;

            // Display the SaveFileDialog by calling ShowDialog method
            bool? result = saveFileDialog.ShowDialog();

            // Check if the user selected a file
            if (result == true)
            {
                // Get the selected file name
                string fileName = saveFileDialog.FileName;

                // Call the SaveToFile method of your Game object
                Game.SaveToFile(fileName);
            }
        }

        public ICommand LoadGameCommand { get; private set; }

        private void LoadGameClick(Object param)
        {
            // Create an OpenFileDialog
            var openFileDialog = new OpenFileDialog();

            // Set default file extension and filter
            openFileDialog.DefaultExt = ".json";
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";

            // Set the initial directory to the desired path
            string initialDirectory = Path.GetFullPath(".\\..\\..\\Resources\\GameFiles");
            openFileDialog.InitialDirectory = initialDirectory;

            // Display the OpenFileDialog by calling ShowDialog method
            bool? result = openFileDialog.ShowDialog();

            // Check if the user selected a file
            if (result == true)
            {
                // Get the selected file name
                string fileName = openFileDialog.FileName;

                // Call the LoadFromFile method of your Game object
                Game.LoadFromFile(fileName);

                // Update UI or perform necessary actions
                UpdateBoard();
                selectedSquare = null;
                UnHighlightMoves();
                TurnMessage = $"Turn: {Game.Turn.ToString()}";
                StatusMessage = "";
                if (Game.IsGameOver())
                {
                    GameOverMessage = $"{Game.Turn.ToString()} wins!";
                }
                else
                {
                    GameOverMessage = "";
                }
                GameJustStarted = false;
            }
        }

    }
}
