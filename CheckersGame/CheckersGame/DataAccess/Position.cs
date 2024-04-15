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

        public override int GetHashCode()
        {
            return (Row, Col).GetHashCode();
        }

        public override string ToString()
        {
            return $"({Row}, {Col})";
        }

        public static bool operator ==(Position position1, Position position2)
        {
            if (ReferenceEquals(position1, position2))
            {
                return true;
            }
            if (position1 is null || position2 is null)
            {
                return false;
            }
            return position1.Row == position2.Row && position1.Col == position2.Col;
        }

        public static bool operator !=(Position position1, Position position2)
        {
            return !(position1 == position2);
        }
    }
}
