using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToeGame.Test.Strategies;

namespace TicTacToeGame.Test
{
    class TicTacToe
    {
        internal Cell[,] Board{get; private set;}

        internal TicTacToe()
        {
            Board = new Cell[3, 3];
        }

        internal void AIMove()
        {
            var centerStrategy = new CenterStrategy();
            var oppositeCornerStrategy = new OppositeCornerStrategy();
            var freeCornerStrategy = new FreeCornerStrategy();

            if (centerStrategy.CanHandle(Board))
                centerStrategy.Update(Board);
            else if (oppositeCornerStrategy.CanHandle(Board))
                oppositeCornerStrategy.Update(Board);
            else if (freeCornerStrategy.CanHandle(Board))
                freeCornerStrategy.Update(Board);
        }       

        private void FillCell(int row, int column, Cell cell)
        {
            Board[row, column] = cell;
        }

        internal void OpponentMove(int row, int column)
        {
            FillCell(row, column, Cell.Opponent);
        }
    }
}