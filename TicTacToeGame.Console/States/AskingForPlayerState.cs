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

        public override void Evaluate()
        {
            try
            {
                TicTacToeConsoleRunner.consoleIO.WriteLine(Resources.SelectPlayer);
                string userSelected = TicTacToeConsoleRunner.consoleIO.ReadLine();

                int intUserInput = GetUserInputAsInteger(userSelected);

                if (Enum.IsDefined(typeof(CellType), intUserInput))
                {
                    SetInitialPlayer(userSelected);
                }
            }
            catch { }
        }

        private int GetUserInputAsInteger(string userInput)
        {
            return int.Parse(userInput);
        }

        private void SetInitialPlayer(string userInput)
        {
            CellType userToStart;
            Enum.TryParse<CellType>(userInput, out userToStart);
            TicTacToeConsoleRunner.ticTacToe.SetInitialPlayer(userToStart);
            TicTacToeConsoleRunner.State = new PlayingState(this);
        }
    }
}