using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            if (BoardIsEmpty())
                FillCell(1, 1, Cell.AI);
            else if (Board[0, 0] == Cell.Empty)
                FillCell(0, 0, Cell.AI);
        }

        private void FillCell(int row, int column, Cell cell)
        {
            Board[row, column] = cell;
        }

        private bool BoardIsEmpty()
        {
            foreach(var cell in Board)
            {
                if (cell != Cell.Empty)
                    return false;
            }

            return true;
        }

        internal void OpponentMove(int row, int column)
        {
            FillCell(row, column, Cell.Opponent);
        }
    }
}