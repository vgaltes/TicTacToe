﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame.Console.States
{
    public class HumanWinsState : TicTacToeConsoleRunnerState
    {
        public HumanWinsState(TicTacToeConsoleRunnerState state)
        {
            this.TicTacToeConsoleRunner = state.TicTacToeConsoleRunner;
        }

        public override void Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}