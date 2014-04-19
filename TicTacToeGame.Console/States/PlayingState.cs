﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Exceptions;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.States
{
    public class PlayingState : TicTacToeConsoleRunnerState
    {
        private const string QUIT_COMMAND = "q!";

        public PlayingState(TicTacToeConsoleRunnerState state)
        {
            this.TicTacToeConsoleRunner = state.TicTacToeConsoleRunner;
        }

        public PlayingState(TicTacToeConsoleRunner tttConsoleRunner)
        {
            this.TicTacToeConsoleRunner = tttConsoleRunner;
        }
        public override void Evaluate()
        {
            this.TicTacToeConsoleRunner.consoleIO.WriteLine(Resources.WriteCoordinates);
            string userInput = this.TicTacToeConsoleRunner.consoleIO.ReadLine();

            if (userInput == QUIT_COMMAND)
            {
                this.TicTacToeConsoleRunner.State = new QuitGameState(this);
            }
            else
            {
                try
                {
                    var cellCoordinates = GetCoordinatesFromUserInput(userInput);
                    this.TicTacToeConsoleRunner.ticTacToe.OpponentMove(cellCoordinates);
                }
                catch ( NotAllowedMovementException)
                {
                    this.InfoFromPreviousStep = Resources.NotAllowedMovement;
                }
            }
        }

        private CellCoordinates GetCoordinatesFromUserInput(string userInput)
        {
            int[] coordinates = userInput.Split(',').Select(c => int.Parse(c)).ToArray();
            VerifyCoordinatesAreInTheBoard(coordinates);
            return new CellCoordinates(coordinates[0], coordinates[1]);
        }

        private void VerifyCoordinatesAreInTheBoard(int[] coordinates)
        {
            if (coordinates[0] > TicTacToeConsoleRunner.ticTacToe.Board.Size ||
                coordinates[1] > TicTacToeConsoleRunner.ticTacToe.Board.Size ||
                coordinates[0] < 0 ||
                coordinates[1] < 0)
                throw new NotAllowedMovementException();
        }
    }
}
