using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class FreeSideStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Board board)
        {
            foreach ( var side in board.Sides)
            {
                if ( board.IsCellOfType(CellType.Empty, side))
                    return true;
            }

            return false;
        }

        public void Update(Board board)
        {
            foreach (var side in board.Sides)
            {
                if (board.IsCellOfType(CellType.Empty, side))
                {
                    board.FillAICell(side);
                }
            }
        }
    }
}