using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame.Console
{
    public class TicTacToeConsoleRunner
    {
        private ITicTacToe ticTacToe;
        private TicTacToeBoardDrawer ticTacToeBoardDrawer;
        private ConsoleIO consoleIO;

        public TicTacToeConsoleRunner(ITicTacToe ticTacToe, TicTacToeBoardDrawer ticTacToeBoardDrawer, ConsoleIO consoleIO)
        {
            // TODO: Complete member initialization
            this.ticTacToe = ticTacToe;
            this.ticTacToeBoardDrawer = ticTacToeBoardDrawer;
            this.consoleIO = consoleIO;
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
