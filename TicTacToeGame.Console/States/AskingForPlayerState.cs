using System;
using System.Linq;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.States
{
    public class AskingForPlayerState : TicTacToeConsoleRunnerState
    {
        int[] allowedPlayers = new int[2] { 1, 2 };
        public AskingForPlayerState(TicTacToeConsoleRunner ticTacTeoConsoleRunner)
        {
            TicTacToeConsoleRunner = ticTacTeoConsoleRunner;
        }

        public AskingForPlayerState(TicTacToeConsoleRunnerState state)
        {
            TicTacToeConsoleRunner = state.TicTacToeConsoleRunner;
        }

        public override void Evaluate()
        {
            try
            {
                DrawInputMessages();
                int initialPlayer = GetInitialPlayerSelectedByUser();

                if (allowedPlayers.Contains(initialPlayer))
                {
                    SetInitialPlayer(initialPlayer);
                }
                else
                {
                    InfoFromPreviousStep = Resources.SelectPlayer_InvalidOption;
                }
            }
            catch 
            {
                InfoFromPreviousStep = Resources.SelectPlayer_InvalidOption;
            }
        }

        private void DrawInputMessages()
        {
            TicTacToeConsoleRunner.consoleIO.Clear();
            TicTacToeConsoleRunner.DrawHeader();
            TicTacToeConsoleRunner.consoleIO.WriteLine(Resources.SelectPlayer);
            TicTacToeConsoleRunner.consoleIO.WriteLine(string.Empty);
            TicTacToeConsoleRunner.consoleIO.Write("> ");
        }

        private int GetInitialPlayerSelectedByUser()
        {
            string userSelected = TicTacToeConsoleRunner.consoleIO.ReadLine();
            return int.Parse(userSelected);
        }

        private void SetInitialPlayer(int initialPlayerSelected)
        {
            
            TicTacToeConsoleRunner.State = new PlayingState(this, initialPlayerSelected);
        }
    }
}