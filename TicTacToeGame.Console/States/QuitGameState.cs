using System;

namespace TicTacToeGame.Console.States
{
    public class QuitGameState : TicTacToeConsoleRunnerState
    {
        public QuitGameState(TicTacToeConsoleRunnerState state)
        {
            this.TicTacToeConsoleRunner = state.TicTacToeConsoleRunner;
        }

        public QuitGameState(TicTacToeConsoleRunner tttConsoleRunner)
        {
            this.TicTacToeConsoleRunner = tttConsoleRunner;
        }

        public override void Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}