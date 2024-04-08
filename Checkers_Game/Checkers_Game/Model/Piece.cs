namespace Checkers_Game.Model
{
    public class Piece : BaseNotification
    {

        private EType piceType;

        private EColor pieceColor;

        public Piece(EType type, EColor color)
        {
            piceType = type;
            pieceColor = color;
        }

        public EType PieceType
        {
            get { return piceType; }
            set
            {
                piceType = value;
                NotifyPropertyChanged();
            }
        }

        public EColor PieceColor
        {
            get { return pieceColor; }
            set
            {
                pieceColor = value;
                NotifyPropertyChanged();
            }
        }
    }
}
