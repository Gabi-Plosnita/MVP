using CheckersGame.DataAccess;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CheckersGame.BusinessLogic
{
    public abstract class Piece : BaseNotification
    {

        protected EType pieceType;

        protected EColor pieceColor;

        protected Piece(EType type, EColor color)
        {
            pieceType = type;
            pieceColor = color;
        }

        public EType PieceType
        {
            get { return pieceType; }
            set
            {
                pieceType = value;
                NotifyPropertyChanged();
            }
        }

        public EColor PieceColor
        {
            get { return pieceColor; }
        }

        public void SubscribeToPropertyChanged(PropertyChangedEventHandler handler)
        {
            PropertyChanged += handler;
        }

        public abstract List<Position> GetPossibleMoves(Position piecePosition, 
            ObservableCollection<ObservableCollection<Piece>> board);

    }
}
