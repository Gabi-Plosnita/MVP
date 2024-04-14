using CheckersGame.BusinessLogic;
using CheckersGame.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CheckersGame.ViewModel
{
    public class MainViewModel
    {
        private Game Game = new Game();

        public ObservableCollection<Square> Board;

        public MainViewModel()
        {
            InitializeBoard();
            SqaureClickCommand = new RelayCommand<Square>(SqaureClick);
        }

        private void InitializeBoard()
        {
            Board = new ObservableCollection<Square>();

            for (int i = 0; i < Game.Board.Count; i++)
            {
                for (int j = 0; j < Game.Board[i].Count; j++)
                {
                    Square square = new Square();
                    if(i + j % 2 != 0)
                    {
                        square.BackgroundImagePath = ".\\..\\..\\Resources\\bg1.png";
                    }
                    else
                    {
                        square.BackgroundImagePath = ".\\..\\..\\Resources\\bg2.png";
                    }
                    square.Piece = Game.Board[i][j];
                    Board.Add(square);
                }
            }
        }

        public ICommand SqaureClickCommand { get; private set; }

        private void SqaureClick(Square square)
        {
            square.ImagePath = ".\\..\\..\\Resources\\bg1.png";
        }
    }
}
