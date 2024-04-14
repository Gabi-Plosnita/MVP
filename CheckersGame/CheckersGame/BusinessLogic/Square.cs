using CheckersGame.DataAccess;

namespace CheckersGame.BusinessLogic
{
    public class Square : BaseNotification
    {
        public string BackgroundImagePath { get; set; }

        public Position Position { get; set; }

        public string ImagePath
        {
            get
            {
                return Piece.ImagePath;
            }
            set
            {
                Piece.ImagePath = value;
                NotifyPropertyChanged();
            }
        }

        public Piece Piece;
    }
}
