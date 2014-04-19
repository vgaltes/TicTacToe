using System;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.States
{
    public class AskingForPlayerState : TicTacToeConsoleRunnerState
    {
        public AskingForPlayerState(TicTacToeConsoleRunner ticTacTeoConsoleRunner)
        {
            TicTacToeConsoleRunner = ticTacTeoConsoleRunner;
        }

        public override void Evaluate(string userInput)
        {
            var initialPlayer = (CellType)Enum.Parse(typeof(CellType), userInput);
            TicTacToeConsoleRunner.ticTacToe.SetInitialPlayer(initialPlayer);
            TicTacToeConsoleRunner.State = new PlayingState(this);
        }
    }
}