using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame.Console.States
{
    public class DrawState : TicTacToeConsoleRunnerState
    {
        public DrawState(TicTacToeConsoleRunnerState state)
        {
            this.TicTacToeConsoleRunner = state.TicTacToeConsoleRunner;
        }

        public DrawState(TicTacToeConsoleRunner tttConsoleRunner)
        {
            this.TicTacToeConsoleRunner = tttConsoleRunner;
        }

        public override void Evaluate()
        {
            this.TicTacToeConsoleRunner.consoleIO.WriteLine(Resources.Draw);
            this.TicTacToeConsoleRunner.consoleIO.ReadKey();
            this.TicTacToeConsoleRunner.State = new AskingForPlayerState(this);
        }
    }
}