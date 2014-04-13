using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TicTacToeGame.Exceptions;
using TicTacToeGame.Models;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Console
{
    class Program
    {
        private const string MOVEMENT_NOT_ALLOWED =
            "MOVEMENT NOT ALLOWED. PLEASE ENTER NEW COORDINATES.";
        private const string UNEXPECTED_EXCEPTION =
            "UNEXPECTED EXCEPTION HAS OCURRED. PLEASE ENTER NEW COORDINATES.";
        private const string QUIT_COMMAND = "q!";
        private const string SELECT_PLAYER = "Press 1 to let AI make the first movement.\nPress 2 to make you the first movement.";
        private const string WRITE_COORDINATES = "Write the coordinates where you want to move. \nThe format is [row],[column].\nWrite q! to quit.";
        private const string AI_WINS = "AI WINS! Press any key to restart game.";
        private const string YOU_WIN = "YOU WIN! Press any key to restart game.";
        private const string DRAW = "DRAW! Press any key to restart game.";
        private static string extraInfo = string.Empty;

        static void Main(string[] args)
        {
            var ticTacToe = CreateTicTacToe();
            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();

            SetInitialPlayer(ticTacToe);
            DrawBoard(ticTacToe, ticTacToeBoardDrawer);

            string userInput = GetUserInput(ticTacToe);
            while (userInput != QUIT_COMMAND)
            {
                userInput = RunGame(ticTacToe, ticTacToeBoardDrawer, userInput);
            }
        }

        private static string RunGame(ITicTacToe ticTacToe, TicTacToeBoardDrawer ticTacToeBoardDrawer, string userInput)
        {
            if (ticTacToe.State == TicTacToeState.Playing)
            {
                PlayGame(ticTacToe, userInput);
            }

            DrawBoard(ticTacToe, ticTacToeBoardDrawer);

            if ( ticTacToe.State != TicTacToeState.Playing)
            {
                System.Console.ReadKey();
                ResetGame(ticTacToe, ticTacToeBoardDrawer);
            }

            userInput = GetUserInput(ticTacToe);

            return userInput;
        }

        private static void PlayGame(ITicTacToe ticTacToe, string userInput)
        {
            try
            {
                extraInfo = WRITE_COORDINATES;
                ticTacToe.OpponentMove(GetCoordinatesFromUserInput(userInput));
            }
            catch (NotAllowedMovementException)
            {
                extraInfo = string.Format("{0}\n{1}", MOVEMENT_NOT_ALLOWED, WRITE_COORDINATES);
            }
            catch (Exception)
            {
                extraInfo = string.Format("{0}\n{1}", UNEXPECTED_EXCEPTION, WRITE_COORDINATES);
            }
        }

        private static void ResetGame(ITicTacToe ticTacToe, TicTacToeBoardDrawer ticTacToeBoardDrawer)
        {
            System.Console.Clear();
            ticTacToe.Reset();
            SetInitialPlayer(ticTacToe);
            DrawBoard(ticTacToe, ticTacToeBoardDrawer);
        }

        private static string GetUserInput(ITicTacToe ticTacToe)
        {
            string line = string.Empty;
            string regexExpression = string.Format("[\\d],[\\d]", ticTacToe.Board.Size - 1);

            while (line != QUIT_COMMAND && !Regex.IsMatch(line, regexExpression))
            {
                line = System.Console.ReadLine();
            }
            return line;
        }

        private static CellCoordinates GetCoordinatesFromUserInput(string userInput)
        {
            int[] coordinates = userInput.Split(',').Select(c => int.Parse(c)).ToArray();
            return new CellCoordinates(coordinates[0], coordinates[1]);
        }

        private static void DrawBoard(ITicTacToe ticTacToe, TicTacToeBoardDrawer ticTacToeBoardDrawer)
        {
            System.Console.Clear();

            if (ticTacToe.State == TicTacToeState.AIWins)
                extraInfo = AI_WINS;
            else if (ticTacToe.State == TicTacToeState.OpponentWins)
                extraInfo = YOU_WIN;
            else if (ticTacToe.State == TicTacToeState.Draw)
                extraInfo = DRAW;

            string boardAsString = ticTacToeBoardDrawer.GetRepresentationOf(ticTacToe.Board);
            
            System.Console.WriteLine(extraInfo);
            System.Console.WriteLine(boardAsString);
        }

        private static ITicTacToe CreateTicTacToe()
        {
            var strategies = new List<TicTacToeStrategy>
            {
                new WinStrategy(),
                new BlockStrategy(),
                new ForkStrategy(),
                new BlockForkStrategy(),
                new CenterStrategy(),
                new OppositeCornerStrategy(),
                new FreeCornerStrategy(),
                new FreeSideStrategy()
            };

            var board = new Board();

            ITicTacToe ticTacToe = new TicTacToe(board, strategies);
            return ticTacToe;
        }

        private static void SetInitialPlayer(ITicTacToe ticTacToe)
        {
            System.Console.WriteLine(SELECT_PLAYER);
            var option = System.Console.ReadLine();
            if (option != "1" && option != "2")
                SetInitialPlayer(ticTacToe);
            else
            {
                var initialPlayer = (CellType)Enum.Parse(typeof(CellType), option);
                ticTacToe.SetInitialPlayer(initialPlayer);
                extraInfo = WRITE_COORDINATES;
            }
        }
    }
}