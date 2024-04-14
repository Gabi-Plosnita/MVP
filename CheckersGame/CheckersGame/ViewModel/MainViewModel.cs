using CheckersGame.BusinessLogic;
using CheckersGame.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;

namespace CheckersGame.ViewModel
{
    public class MainViewModel
    {
        private Game Game = new Game();

        public ObservableCollection<Square> Board { get; private set; }

        private Square selectedSquare = null;

        public MainViewModel()
        {
            InitializeBoard();
            SquareClickCommand = new RelayCommand<Square>(SquareClick);
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

        private void HighlightMoves(Position position)
        {
            List<Position> moves = Game.GetMoves(position);
            foreach(Position move in moves)
            {
                Board[move.Row * 8 + move.Col].BackgroundImagePath = ".\\..\\..\\Resources\\highlight.png";
            }

        }

        public ICommand SquareClickCommand { get; private set; }

        private void SquareClick(Square square)
        {
            if(selectedSquare == null)
            {
                if(square.Piece.PieceColor == Game.Turn)
                {
                    selectedSquare = square;
                    HighlightMoves(square.Position);
                }
            }
            else
            {
                if(selectedSquare == square)
                {
                    selectedSquare = null;
                }
                else
                {
                    Game.MakeMove(selectedSquare.Position, square.Position);
                    selectedSquare = null;
                }
                // unhighlight moves
            }
        }
    }
}
