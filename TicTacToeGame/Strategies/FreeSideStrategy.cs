using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class FreeSideStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Board board)
        {
            return GetFirstEmptyCellCoordinatesInASide(board).IsValid;
        }

        public void Update(Board board)
        {
            board.FillAICell(GetFirstEmptyCellCoordinatesInASide(board));
        }

        private CellCoordinates GetFirstEmptyCellCoordinatesInASide(Board board)
        {
            foreach ( var side in board.Sides)
            {
                if (board.IsCellOfType(CellType.Empty, side))
                    return side;
            }

            return CellCoordinates.InvalidCoordinates;
        }
    }
}