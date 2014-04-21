using System;
using System.Linq;
using TicTacToeGame.Exceptions;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.Players
{
    public class HumanPlayer : Player
    {
        ConsoleIO consoleIO;
        ITicTacToe ticTacToe;

        public HumanPlayer(ConsoleIO consoleIO, ITicTacToe ticTacToe)
        {
            this.consoleIO = consoleIO;
            this.ticTacToe = ticTacToe;
        }

        public void Move(string userInput)
        {
            var cellCoordinates = GetCoordinatesFromUserInput(userInput);
            ticTacToe.HumanMove(cellCoordinates);
        }

        public string AskForUserInput()
        {
            consoleIO.WriteLine(Resources.WriteCoordinates);
            return consoleIO.ReadLine();
        }

        private CellCoordinates GetCoordinatesFromUserInput(string userInput)
        {
            VerifyCoordinatesAreValidIntegers(userInput);
            int[] coordinates = userInput.Split(',').Select(c => int.Parse(c)).ToArray();
            VerifyCoordinatesAreInTheBoard(coordinates);

            return new CellCoordinates(coordinates[0], coordinates[1]);
        }

        private void VerifyCoordinatesAreInTheBoard(int[] coordinates)
        {
            if (coordinates[0] > ticTacToe.Board.Size ||
                coordinates[1] > ticTacToe.Board.Size ||
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