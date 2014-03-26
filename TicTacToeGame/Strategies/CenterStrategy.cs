using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Strategies
{
    internal class CenterStrategy
    {
        internal bool CanHandle(Cell[,] board)
        {
            foreach (var cell in board)
            {
                if (cell != Cell.Empty)
                    return false;
            }

            return true;
        }

        internal void Update(Cell[,] board)
        {
            board[1, 1] = Cell.AI;
        }
    }
}