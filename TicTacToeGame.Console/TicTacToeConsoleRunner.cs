﻿using TicTacToeGame.Console.Players;
using TicTacToeGame.Console.States;

namespace TicTacToeGame.Console
{
    public class TicTacToeConsoleRunner
    {
        public readonly Board board;
        public readonly TicTacToeBoardDrawer ticTacToeBoardDrawer;
        public readonly ConsoleIO consoleIO;
        public readonly Player[] Players;
        private const string header =
                @"  _______ _        _______           _______
 |__   __(_)      |__   __|         |__   __|        
    | |   _  ___     | | __ _  ___     | | ___   ___ 
    | |  | |/ __|    | |/ _` |/ __|    | |/ _ \ / _ \
    | |  | | (__     | | (_| | (__     | | (_) |  __/
    |_|  |_|\___|    |_|\__,_|\___|    |_|\___/ \___|



";

        public TicTacToeConsoleRunnerState State { get; set; }

        public TicTacToeConsoleRunner(Board board, TicTacToeBoardDrawer ticTacToeBoardDrawer, ConsoleIO consoleIO,
            Player player1, Player player2)
        {
            this.board = board;
            this.ticTacToeBoardDrawer = ticTacToeBoardDrawer;
            this.consoleIO = consoleIO;
            Players = new Player[2] { player1, player2 };
            this.State = new AskingForPlayerState(this);
        }

        public void Run()
        {
            while ( !State.IsFinished)
            {
                State.Evaluate();
            }
        }

        public void DrawBoard()
        {
            var boardRepresentation = ticTacToeBoardDrawer.GetRepresentationOf(board);

            consoleIO.WriteLine(boardRepresentation);
        }

        public void DrawHeader()
        {
            consoleIO.Clear();
            consoleIO.SetForegroundColor(System.ConsoleColor.DarkBlue);            
            consoleIO.WriteLine(header);
            consoleIO.ResetColor();
        }
    }
}