using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame.Console
{
    public class TicTacToeConsoleRunner
    {
        private readonly ITicTacToe ticTacToe;
        private readonly TicTacToeBoardDrawer ticTacToeBoardDrawer;
        private readonly ConsoleIO consoleIO;

        public TicTacToeConsoleRunner(ITicTacToe ticTacToe, TicTacToeBoardDrawer ticTacToeBoardDrawer, ConsoleIO consoleIO)
        {
            this.ticTacToe = ticTacToe;
            this.ticTacToeBoardDrawer = ticTacToeBoardDrawer;
            this.consoleIO = consoleIO;
        }

        public void Run()
        {
            SetInitialPlayer();
        }

        private void SetInitialPlayer()
        {
            consoleIO.WriteLine(Resources.SelectPlayer);
            var option = consoleIO.ReadLine();
            if (option != "1" && option != "2")
                SetInitialPlayer();
        }
    }
}
