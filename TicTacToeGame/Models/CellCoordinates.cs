namespace TicTacToeGame.Models
{
    public class CellCoordinates
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public CellCoordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}