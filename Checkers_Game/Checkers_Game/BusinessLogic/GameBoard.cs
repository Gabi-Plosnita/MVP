using Checkers_Game.Model;

namespace Checkers_Game.BusinessLogic
{
    public class GameBoard : BaseNotification
    {
        public Piece[,] board { get; private set; }

        public EColor turn { get; private set;}

        public GameBoard()
        {
            board = new Piece[8, 8];
            turn = EColor.Red;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for(int row=0; row<8; row++)
            {
                for(int col=0; col<8; col++)
                {
                    if( (row == 0 || row == 2 || row == 6) && (col % 2 == 1) )
                    {
                        if(row == 0 || row == 2)
                        {
                            board[row, col] = new Piece(EType.NormalPiece, EColor.Black);
                        }
                        else
                        {
                            board[row, col] = new Piece(EType.NormalPiece, EColor.Red);
                        }
                    }
                    else if( (row == 1 || row == 5 || row == 7) && (col % 2 == 0) )
                    {
                        if(row == 1)
                        {
                            board[row, col] = new Piece(EType.NormalPiece, EColor.Black);
                        }
                        else
                        {
                            board[row, col] = new Piece(EType.NormalPiece, EColor.Red);
                        }
                    }
                    else
                    {
                        board[row, col] = new Piece(EType.None, EColor.None);
                    }
                }
            }
        }

        public Piece GetPiece(int row, int col)
        {
            return board[row, col];
        }

        public void SwitchTurn()
        {
            turn = EColor.Red == turn ? EColor.Black : EColor.Red;
        }



    }
}
