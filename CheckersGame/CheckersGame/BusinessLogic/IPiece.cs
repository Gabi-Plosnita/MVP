using CheckersGame.DataAccess;
using System.Collections.Generic;
using System.ComponentModel;

namespace CheckersGame.BusinessLogic
{
    public interface IPiece : INotifyPropertyChanged
    {
        EType GetType();

        EColor GetColor();

        void SetType(EType type);

        List<Position> GetPossibleMoves(Piece[,] board);

        void SubscribeToPropertyChanged(PropertyChangedEventHandler handler);

    }
}
