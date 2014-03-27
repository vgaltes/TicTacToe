using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame.Console.Test
{
    class TicTacToeBoardDrawer
    {
        internal string GetRepresentationOf(Cell[,] board)
        {
            return " | | \n-----\n | | \n-----\n | | ";
        }
    }
}
