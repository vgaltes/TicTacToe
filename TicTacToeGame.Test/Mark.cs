using TicTacToeGame.Models;
namespace TicTacToeGame.Test
{
    public class Mark
    {
        private const char AI_MARK = 'X';
        private const char OPPONENTS_MARK = 'O';

        public CellCoordinates CellCoordinate { get; private set; }

        public char Cell { get; private set; }

        public Mark(char cell, CellCoordinates cellCoordinate)
        {
            Cell = cell;
            CellCoordinate = cellCoordinate;
        }

        internal static Mark AIFromCoordinates(int row, int column)
        {
            return new Mark(AI_MARK, new CellCoordinates(row, column));
        }

        internal static Mark OpponentFromCoordinates(int row, int column)
        {
            return new Mark(OPPONENTS_MARK, new CellCoordinates(row, column));
        }
    }
}