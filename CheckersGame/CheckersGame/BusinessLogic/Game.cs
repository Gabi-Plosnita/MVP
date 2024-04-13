using CheckersGame.DataAccess;
using System.Collections.Generic;

namespace CheckersGame.BusinessLogic
{
    public class Game
    {
        private List<List<Piece>> board;
        public List<List<Piece>> Board
        {
            get { return board; }
        }

        private EColor turn;
        public EColor Turn
        {
            get { return turn; }
        }

        public Game()
        {
            InitializeBoard();
            turn = EColor.Red;
        }

        private void InitializeBoard()
        {
            board = new List<List<Piece>>();
            for (int i = 0; i < 8; i++)
            {
                board.Add(new List<Piece>());
                for (int j = 0; j < 8; j++)
                {
                    if (i < 3 && (i + j) % 2 != 0)
                    {
                        board[i].Add(new Piece(EType.NormalPiece, EColor.Black));
                    }
                    else if (i > 4 && (i + j) % 2 != 0)
                    {
                        board[i].Add(new Piece(EType.NormalPiece, EColor.Red));
                    }
                    else
                    {
                        board[i].Add(new Piece(EType.None, EColor.None));
                    }
                }
            }
        }

        public void SwitchTurn()
        {
            turn = turn == EColor.Black ? EColor.Red : EColor.Black;
        }

    }
}
