using System;
using System.Linq;
using TicTacToeGame.Exceptions;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.Players
{
    public class HumanPlayer : Player
    {
        ConsoleIO consoleIO;

        public HumanPlayer(ConsoleIO consoleIO, char mark)
        {
            this.consoleIO = consoleIO;
            this.Mark = mark;
        }

        public void Move(Board board, string userInput)
        {
            var cellCoordinates = GetCoordinatesFromUserInput(board, userInput);
            board.FillCell(cellCoordinates, Mark);
        }

        public string AskForUserInput()
        {
            consoleIO.WriteLine(Resources.WriteCoordinates);
            consoleIO.WriteHorizontalSeparator();
            consoleIO.WriteLine(string.Empty);
            consoleIO.WritePrompt();
            return consoleIO.ReadLine();
        }

        public char Mark { get; set; }

        private CellCoordinates GetCoordinatesFromUserInput(Board board, string userInput)
        {
            VerifyCoordinatesAreValidIntegers(userInput);
            int[] coordinates = userInput.Split(',').Select(c => int.Parse(c)).ToArray();
            VerifyCoordinatesAreInTheBoard(board, coordinates);

            return new CellCoordinates(coordinates[0], coordinates[1]);
        }

        private void VerifyCoordinatesAreInTheBoard(Board board, int[] coordinates)
        {
            if (coordinates[0] > board.Size ||
                coordinates[1] > board.Size ||
                coordinates[0] < 0 ||
                coordinates[1] < 0)
                throw new NotAllowedMovementException();
        }

        private void VerifyCoordinatesAreValidIntegers(string line)
        {
            int[] intCoordinates = new int[2];
            bool rowValid = false;
            bool columnValid = false;

            string[] coordinates = line.Split(',');

            if (coordinates == null || coordinates.Length != 2)
                throw new NotAllowedMovementException();

            rowValid = int.TryParse(coordinates[0], out intCoordinates[0]);
            columnValid = int.TryParse(coordinates[1], out intCoordinates[1]);

            if (!rowValid || !columnValid)
                throw new NotAllowedMovementException();
        }
    }
}