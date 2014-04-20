﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame.Console.States
{
    public class AIWinsState : TicTacToeConsoleRunnerState
    {
        public AIWinsState(TicTacToeConsoleRunnerState state)
        {
            this.TicTacToeConsoleRunner = state.TicTacToeConsoleRunner;
        }

        public AIWinsState(TicTacToeConsoleRunner tttConsoleRunner)
        {
            TicTacToeConsoleRunner = tttConsoleRunner;
        }

        public override void Evaluate()
        {
            this.TicTacToeConsoleRunner.consoleIO.WriteLine(Resources.AiWins);
            this.TicTacToeConsoleRunner.consoleIO.ReadKey();
            this.TicTacToeConsoleRunner.State = new AskingForPlayerState(this);
        }
    }
}