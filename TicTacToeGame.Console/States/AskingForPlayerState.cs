using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Console.States
{
    public class AskingForPlayerState : TicTacToeConsoleRunnerState
    {
        TicTacToeConsoleRunner ticTacToeConsoleRunner;

        public AskingForPlayerState(TicTacToeConsoleRunner ticTacTeoConsoleRunner)
        {
            this.ticTacToeConsoleRunner = ticTacTeoConsoleRunner;
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
