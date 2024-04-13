using CheckersGame.BusinessLogic;
using System.Collections.ObjectModel;

namespace CheckersGame.ViewModel
{
    public class MainViewModel
    {
        private Game game;
        public ObservableCollection<ObservableCollection<Piece>> Board => game.Board;
        public MainViewModel()
        {
            game = new Game();
        }

        
    }
}
