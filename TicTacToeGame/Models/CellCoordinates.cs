namespace TicTacToeGame.Models
{
    public class CellCoordinates
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public bool IsValid { get; private set; }

        public CellCoordinates(int row, int column) : this(row, column, true){}

        private CellCoordinates(int row, int column, bool isValid)
        {
            Row = row;
            Column = column;
            IsValid = isValid;
        }

        public static CellCoordinates InvalidCoordinates
        {
            get
            {
                return new CellCoordinates(-1, -1, false);
            }
        }
    }
}