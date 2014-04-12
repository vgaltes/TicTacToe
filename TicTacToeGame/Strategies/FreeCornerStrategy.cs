using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class FreeCornerStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Board board)
        {
            return GetFirstEmptyCellCoordinatesInACorner(board).IsValid;
        }

        public void Update(Board board)
        {
            board.FillAICell(GetFirstEmptyCellCoordinatesInACorner(board));
        }

        private CellCoordinates GetFirstEmptyCellCoordinatesInACorner(Board board)
        {
            foreach (var corner in board.Corners)
            {
                if (board.IsCellOfType(CellType.Empty, corner))
                    return corner;
            }

            return CellCoordinates.InvalidCoordinates;
        }
    }
}