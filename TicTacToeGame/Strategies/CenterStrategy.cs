using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Strategies
{
    public class CenterStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Cell[,] board)
        {
            foreach (var cell in board)
            {
                if (cell != Cell.Empty)
                    return false;
            }

            return true;
        }

        public void Update(Cell[,] board)
        {
            board[1, 1] = Cell.AI;
        }
    }
}