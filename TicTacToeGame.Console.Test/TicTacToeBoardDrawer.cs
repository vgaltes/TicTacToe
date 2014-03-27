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
            return string.Format("{0}|{1}|{2}\n-----\n{3}|{4}|{5}\n-----\n{6}|{7}|{8}",
                Draw(board[0, 0]), Draw(board[0, 1]), Draw(board[0, 2]),
                Draw(board[1, 0]), Draw(board[1, 1]), Draw(board[1, 2]),
                Draw(board[2, 0]), Draw(board[2, 1]), Draw(board[2, 2]));
        }

        private string Draw(Cell cell)
        {
            if (cell == Cell.AI)
                return "X";
            if (cell == Cell.Opponent)
                return "O";
            return " ";
        }
    }
}