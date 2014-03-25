using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame.Test
{
    class TicTacToe
    {
        internal Cell[,] Board{get; private set;}

        internal void AIMove()
        {
            Board = new Cell[3, 3]{{Cell.Empty, Cell.Empty, Cell.Empty},
                                                {Cell.Empty, Cell.AI, Cell.Empty},
                                                {Cell.Empty, Cell.Empty, Cell.Empty}};
        }

        internal void OpponentMove(int p1, int p2)
        {
            throw new NotImplementedException();
        }
    }
}
