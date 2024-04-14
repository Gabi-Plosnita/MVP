using CheckersGame.BusinessLogic;
using CheckersGame.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CheckersGame.ViewModel
{
    public class MainViewModel
    {
        private Game Game = new Game();

        public ObservableCollection<Square> Board { get; private set; }

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
                    square.Piece = Game.Board[i][j];
                    Board.Add(square);
                }
            }
        }

        public ICommand SquareClickCommand { get; private set; }

        private void SquareClick(Square square)
        {
            square.ImagePath = ".\\..\\..\\Resources\\bg1.png";
        }
    }
}
