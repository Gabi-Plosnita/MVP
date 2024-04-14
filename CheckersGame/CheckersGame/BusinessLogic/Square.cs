using CheckersGame.DataAccess;

namespace CheckersGame.BusinessLogic
{
    public class Square : BaseNotification
    {
        private string backgroundImagePath;
        public string BackgroundImagePath
        {
            get { return backgroundImagePath; }
            set
            {
                backgroundImagePath = value;
                NotifyPropertyChanged();
            }
        }

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
