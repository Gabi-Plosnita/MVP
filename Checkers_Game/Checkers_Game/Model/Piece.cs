namespace Checkers_Game.Model
{
    public class Piece : BaseNotification
    {

        private EType pieceType;

        public EColor PieceColor { get; };

        public Piece(EType type, EColor color)
        {
            piceType = type;
            pieceColor = color;
        }

        public EType PieceType
        {
            get { return piceType; }
            protected set
            {
                piceType = value;
                NotifyPropertyChanged();
            }
        }


        public abstract List<Position> GetPossibleMoves(Piece[,] board); 
    }
}
