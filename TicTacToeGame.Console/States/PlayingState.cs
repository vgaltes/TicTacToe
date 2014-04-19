using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Console.States
{
    public class PlayingState : TicTacToeConsoleRunnerState
    {
        public PlayingState(TicTacToeConsoleRunnerState state)
        {
            TicTacToeConsoleRunner = state.TicTacToeConsoleRunner;
        }
        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
