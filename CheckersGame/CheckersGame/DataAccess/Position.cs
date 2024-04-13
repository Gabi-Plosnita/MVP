namespace CheckersGame.BusinessLogic
{
    public class Position
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Position other = (Position)obj;
            return Row == other.Row && Col == other.Col;
        }

        public override string ToString()
        {
            return $"({Row}, {Col})";
        }
    }
}
