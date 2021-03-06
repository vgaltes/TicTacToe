﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Console.States
{
    public abstract class TicTacToeConsoleRunnerState
    {
        public TicTacToeConsoleRunner TicTacToeConsoleRunner { get; set; }

        public string InfoFromPreviousStep { get; set; }

        public bool IsFinished { get; protected set; }

        public abstract void Evaluate();
    }
}
