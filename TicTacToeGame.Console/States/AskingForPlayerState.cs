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
            int intUserInput;
            bool isInteger = int.TryParse(userInput, out intUserInput);
            if (!isInteger)
                return;

            if (Enum.IsDefined(typeof(CellType), intUserInput))
            {
                CellType userToStart;
                Enum.TryParse<CellType>(userInput, out userToStart);
                TicTacToeConsoleRunner.ticTacToe.SetInitialPlayer(userToStart);
                TicTacToeConsoleRunner.State = new PlayingState(this);
            }
        }
    }
}