using TicTacToeGame.Models;

namespace TicTacToeGame.Console.States
{
    public class AskingForPlayerState : TicTacToeConsoleRunnerState
    {
        public AskingForPlayerState(TicTacToeConsoleRunner ticTacTeoConsoleRunner)
        {
            TicTacToeConsoleRunner = ticTacTeoConsoleRunner;
        }

        public override void Run()
        {
            TicTacToeConsoleRunner.ticTacToe.SetInitialPlayer(CellType.AI);
            TicTacToeConsoleRunner.State = new PlayingState(this);
        }
    }
}