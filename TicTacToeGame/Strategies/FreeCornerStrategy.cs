using System.Collections.Generic;
using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class FreeCornerStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Board board)
        {
            foreach (var corner in board.Corners)
            {
                if ( board.IsCellOfType(CellType.Empty, corner))
                    return true;
            }

            return false;
        }

        public void Update(Board board)
        {
            foreach (var corner in board.Corners)
            {
                if (board.IsCellOfType(CellType.Empty, corner))
                {
                    board.FillAICell(corner);
                    return;
                }
            }
        }
    }
}