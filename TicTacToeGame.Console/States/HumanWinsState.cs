using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame.Console.States
{
    public class HumanWinsState : TicTacToeConsoleRunnerState
    {
        public HumanWinsState(TicTacToeConsoleRunnerState state)
        {
            this.TicTacToeConsoleRunner = state.TicTacToeConsoleRunner;
        }

        public HumanWinsState(TicTacToeConsoleRunner tttConsoleRunner)
        {
            this.TicTacToeConsoleRunner = tttConsoleRunner;
        }

        public override void Evaluate()
        {
            TicTacToeConsoleRunner.consoleIO.WriteLine(Resources.YouWin);
            TicTacToeConsoleRunner.consoleIO.ReadKey();
            TicTacToeConsoleRunner.board.Reset();
            TicTacToeConsoleRunner.State = new AskingForPlayerState(this);
        }
    }
}