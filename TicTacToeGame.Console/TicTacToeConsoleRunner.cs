﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console
{
    public class TicTacToeConsoleRunner
    {
        private const string AI_PLAYER = "1";
        private const string HUMAN_PLAYER = "2";
        private const string QUIT_COMMAND = "q!";

        private readonly ITicTacToe ticTacToe;
        private readonly TicTacToeBoardDrawer ticTacToeBoardDrawer;
        private readonly ConsoleIO consoleIO;

        private string extraInfo = string.Empty;

        public TicTacToeConsoleRunner(ITicTacToe ticTacToe, TicTacToeBoardDrawer ticTacToeBoardDrawer, ConsoleIO consoleIO)
        {
            this.ticTacToe = ticTacToe;
            this.ticTacToeBoardDrawer = ticTacToeBoardDrawer;
            this.consoleIO = consoleIO;
        }

        public void Run()
        {
            SetInitialPlayer();
            DrawBoard();

            GetUserInput();
        }

        private void SetInitialPlayer()
        {
            consoleIO.WriteLine(Resources.SelectPlayer);
            var option = consoleIO.ReadLine();
            if (option != AI_PLAYER && option != HUMAN_PLAYER)
                SetInitialPlayer();
            else
            {
                var initialPlayer = (CellType)Enum.Parse(typeof(CellType), option);
                ticTacToe.SetInitialPlayer(initialPlayer);
            }
        }

        private void DrawBoard()
        {
            consoleIO.Clear();

            if (ticTacToe.State == TicTacToeState.AIWins)
                extraInfo = Resources.AiWins;
            else if (ticTacToe.State == TicTacToeState.OpponentWins)
                extraInfo = Resources.YouWin;
            else if (ticTacToe.State == TicTacToeState.Draw)
                extraInfo = Resources.Draw;

            consoleIO.WriteLine(extraInfo);

            var board = ticTacToeBoardDrawer.GetRepresentationOf(ticTacToe.Board);
            consoleIO.WriteLine(board);
        }

        private string GetUserInput()
        {
            string line = string.Empty;
            string regexExpression = string.Format("[\\d],[\\d]", ticTacToe.Board.Size - 1);

            while (line != QUIT_COMMAND && !Regex.IsMatch(line, regexExpression))
            {
                line = consoleIO.ReadLine();
            }
            return line;
        }
    }
}
