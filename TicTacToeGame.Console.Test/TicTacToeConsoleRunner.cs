using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame.Console.Test
{
    public class TicTacToeConsoleRunner
    {
        private readonly TicTacToe ticTacToe;

        public TicTacToeConsoleRunner(TicTacToe ticTacToe)
        {
            this.ticTacToe = ticTacToe;
        }

        public void Play(int row, int column)
        {
            ticTacToe.OpponentMove(row, column);
        }
    }
}
