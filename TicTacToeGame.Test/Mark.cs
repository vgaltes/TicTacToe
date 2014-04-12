using TicTacToeGame.Models;
namespace TicTacToeGame.Test
{
    public class Mark
    {
        public CellCoordinates CellCoordinate { get; private set; }

        public CellType Cell { get; private set; }

        public Mark(CellType cell, CellCoordinates cellCoordinate)
        {
            Cell = cell;
            CellCoordinate = cellCoordinate;
        }

        internal static Mark AIFromCoordinates(int row, int column)
        {
            return new Mark(CellType.AI, new CellCoordinates(row, column));
        }

        internal static Mark OpponentFromCoordinates(int row, int column)
        {
            return new Mark(CellType.Opponent, new CellCoordinates(row, column));
        }
    }
}