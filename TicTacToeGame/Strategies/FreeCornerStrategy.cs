using System.Collections.Generic;

namespace TicTacToeGame.Strategies
{
    public class FreeCornerStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Board board)
        {
            foreach (var corner in board.Corners)
            {
                if ( board.IsCellOfType(Cell.Empty, corner.Row, corner.Column))
                    return true;
            }

            return false;
        }

        public void Update(Board board)
        {
            foreach (var corner in board.Corners)
            {
                if (board.IsCellOfType(Cell.Empty, corner.Row, corner.Column))
                {
                    board.FillAICell(corner.Row, corner.Column);
                    return;
                }
            }
        }
    }
}