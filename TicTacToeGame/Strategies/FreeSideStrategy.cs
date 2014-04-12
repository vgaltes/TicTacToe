using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class FreeSideStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Board board)
        {
            return GetEmptyCellInSideCoordinates(board).IsValid;
        }

        public void Update(Board board)
        {
            board.FillAICell(GetEmptyCellInSideCoordinates(board));
        }

        private CellCoordinates GetEmptyCellInSideCoordinates(Board board)
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