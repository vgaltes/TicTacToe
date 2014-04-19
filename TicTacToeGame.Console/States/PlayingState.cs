using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.States
{
    public class PlayingState : TicTacToeConsoleRunnerState
    {
        public PlayingState(TicTacToeConsoleRunnerState state)
        {
            this.TicTacToeConsoleRunner = state.TicTacToeConsoleRunner;
        }

        public PlayingState(TicTacToeConsoleRunner tttConsoleRunner)
        {
            this.TicTacToeConsoleRunner = tttConsoleRunner;
        }
        public override void Evaluate()
        {
            this.TicTacToeConsoleRunner.consoleIO.WriteLine(Resources.WriteCoordinates);
            this.TicTacToeConsoleRunner.consoleIO.ReadLine();

            this.TicTacToeConsoleRunner.ticTacToe.OpponentMove(new CellCoordinates(1, 1));
        }
    }
}
