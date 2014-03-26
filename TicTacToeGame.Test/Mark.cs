namespace TicTacToeGame.Test
{
    public class Mark
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Cell Cell { get; private set; }

        public Mark(int row, int column, Cell cell)
        {
            Row = row;
            Column = column;
            Cell = cell;
        }

        internal static Mark AIFromCoordinates(int row, int column)
        {
            return new Mark(row, column, Cell.AI);
        }

        internal static Mark OpponentFromCoordinates(int row, int column)
        {
            return new Mark(row, column, Cell.Opponent);
        }
    }
}