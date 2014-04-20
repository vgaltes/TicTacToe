﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Exceptions;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.States
{
    public class PlayingState : TicTacToeConsoleRunnerState
    {
        private const string QUIT_COMMAND = "q!";

        private Dictionary<TicTacToeState, Type> nextStates;

        public PlayingState(TicTacToeConsoleRunnerState state)
        {
            this.TicTacToeConsoleRunner = state.TicTacToeConsoleRunner;

            SetNextStates();
        }

        public PlayingState(TicTacToeConsoleRunner tttConsoleRunner)
        {
            this.TicTacToeConsoleRunner = tttConsoleRunner;
        }

        public override void Evaluate()
        {
            WriteInfoFromPreviousStep();
            this.TicTacToeConsoleRunner.consoleIO.WriteLine(Resources.WriteCoordinates);
            DrawBoard();
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

                    SetNextState();
                }
                catch ( NotAllowedMovementException)
                {
                    this.InfoFromPreviousStep = Resources.NotAllowedMovement;
                }
            }
        }

        private void SetNextState()
        {
            if (nextStates.ContainsKey(this.TicTacToeConsoleRunner.ticTacToe.State))
            {
                Type nextState = nextStates[this.TicTacToeConsoleRunner.ticTacToe.State];
                ConstructorInfo constructorInfo = nextState.GetConstructor(new[] { typeof(TicTacToeConsoleRunnerState) });
                this.TicTacToeConsoleRunner.State =
                    (TicTacToeConsoleRunnerState)constructorInfo.Invoke(new object[] { this });
            }
        }

        private void SetNextStates()
        {
            nextStates = new Dictionary<TicTacToeState, Type>();
            nextStates.Add(TicTacToeState.AIWins, typeof(AIWinsState) );
            nextStates.Add(TicTacToeState.OpponentWins, typeof(HumanWinsState));
            nextStates.Add(TicTacToeState.Draw, typeof(DrawState));
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
            if (coordinates[0] > TicTacToeConsoleRunner.ticTacToe.Board.Size ||
                coordinates[1] > TicTacToeConsoleRunner.ticTacToe.Board.Size ||
                coordinates[0] < 0 ||
                coordinates[1] < 0)
                throw new NotAllowedMovementException();
        }

        private void VerifyCoordinatesAreValidIntegers(string line)
        {
            string[] coordinates = line.Split(',');
            int[] intCoordinates = new int[2];
            bool rowValid = int.TryParse(coordinates[0], out intCoordinates[0]);
            bool columnValid = int.TryParse(coordinates[1], out intCoordinates[1]);

            if ( !rowValid || !columnValid )
                throw new NotAllowedMovementException();
        }

        private void WriteInfoFromPreviousStep()
        {
            TicTacToeConsoleRunner.consoleIO.Clear();
            TicTacToeConsoleRunner.consoleIO.WriteLine(InfoFromPreviousStep);
        }

        private void DrawBoard()
        {
            var board = TicTacToeConsoleRunner.ticTacToeBoardDrawer.
                GetRepresentationOf(TicTacToeConsoleRunner.ticTacToe.Board);

            TicTacToeConsoleRunner.consoleIO.WriteLine(board);
        }
    }
}
