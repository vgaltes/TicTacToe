using TicTacToeGame.Models;
namespace TicTacToeGame.Test
{
    public class Mark
    {
        public MarkCoordinate CellCoordinate { get; private set; }

        public Cell Cell { get; private set; }

        public Mark(Cell cell, MarkCoordinate cellCoordinate)
        {
            Cell = cell;
            CellCoordinate = cellCoordinate;
        }

        internal static Mark AIFromCoordinates(int row, int column)
        {
            return new Mark(Cell.AI, new MarkCoordinate(row, column));
        }

        internal static Mark OpponentFromCoordinates(int row, int column)
        {
            return new Mark(Cell.Opponent, new MarkCoordinate(row, column));
        }
    }
}