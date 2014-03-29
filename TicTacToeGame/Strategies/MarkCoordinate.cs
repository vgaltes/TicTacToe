namespace TicTacToeGame.Strategies
{
    public class MarkCoordinate
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public MarkCoordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
