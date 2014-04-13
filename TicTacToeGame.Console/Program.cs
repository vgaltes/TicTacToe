using System;
using System.Collections.Generic;
using System.Linq;
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

        private static string extraInfo = string.Empty;

        static void Main(string[] args)
        {
            var ticTacToe = CreateTicTacToe();
            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();

            DrawBoard(ticTacToe, ticTacToeBoardDrawer);

            string userInput = GetUserInput();
            do
            {
                try
                {
                    extraInfo = string.Empty;
                    ticTacToe.OpponentMove(GetCoordinatesFromUserInput(userInput));
                }
                catch ( NotAllowedMovementException)
                {
                    extraInfo = MOVEMENT_NOT_ALLOWED;
                }
                catch (Exception)
                {
                    extraInfo = UNEXPECTED_EXCEPTION;
                }

                DrawBoard(ticTacToe, ticTacToeBoardDrawer);
                userInput = GetUserInput();

            } while (userInput != QUIT_COMMAND);
        }

        private static string GetUserInput()
        {
            string line = System.Console.ReadLine();
            return line;
        }

        private static CellCoordinates GetCoordinatesFromUserInput(string userInput)
        {
            int[] coordinates = userInput.Split(',').Select(c => int.Parse(c)).ToArray();
            return new CellCoordinates(coordinates[0], coordinates[1]);
        }

        private static void DrawBoard(TicTacToe ticTacToe, TicTacToeBoardDrawer ticTacToeBoardDrawer)
        {
            System.Console.Clear();

            string boardAsString = ticTacToeBoardDrawer.GetRepresentationOf(ticTacToe.Board);
            System.Console.WriteLine(extraInfo);
            System.Console.WriteLine(boardAsString);
        }

        private static TicTacToe CreateTicTacToe()
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

            return new TicTacToe(board, strategies);
        }
    }
}
