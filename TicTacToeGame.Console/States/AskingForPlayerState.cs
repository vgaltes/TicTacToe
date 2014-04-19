﻿using TicTacToeGame.Models;

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
            TicTacToeConsoleRunner.ticTacToe.SetInitialPlayer(CellType.AI);
            TicTacToeConsoleRunner.State = new PlayingState(this);
        }
    }
}