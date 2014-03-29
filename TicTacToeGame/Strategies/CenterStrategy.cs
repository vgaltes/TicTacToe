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
            return board[1, 1] == Cell.Empty;
        }

        public void Update(Cell[,] board)
        {
            board[1, 1] = Cell.AI;
        }
    }
}