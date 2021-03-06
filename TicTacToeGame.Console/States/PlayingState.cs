﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Console.Players;
using TicTacToeGame.Exceptions;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.States
{
    public class PlayingState : TicTacToeConsoleRunnerState
    {
        private const string QUIT_COMMAND = "q!";

        public Player CurrentPlayer {get; set;}

        public PlayingState(TicTacToeConsoleRunnerState state, int initialPlayer)
        {
            this.TicTacToeConsoleRunner = state.TicTacToeConsoleRunner;
            this.CurrentPlayer = state.TicTacToeConsoleRunner.Players[initialPlayer - 1];
        }

        public PlayingState(TicTacToeConsoleRunner tttConsoleRunner)
        {
            this.TicTacToeConsoleRunner = tttConsoleRunner;
            this.CurrentPlayer = tttConsoleRunner.Players[0];
        }

        public override void Evaluate()
        {
            TicTacToeConsoleRunner.DrawHeader();
            WriteInfoFromPreviousStep();
            DrawBoard();
            string userInput = AskForUserInput();

            if (userInput == QUIT_COMMAND)
            {
                this.TicTacToeConsoleRunner.State = new QuitGameState(this);
            }
            else
            {
                  try
                {
                    this.CurrentPlayer.Move(TicTacToeConsoleRunner.board, userInput);
                    if (HasToChangeState())
                        SetNextState();
                    else
                        SetNextPlayer();
                }
                catch (NotAllowedMovementException)
                {
                    this.InfoFromPreviousStep = Resources.NotAllowedMovement;
                }
            }
        }

        private string AskForUserInput()
        {
            TicTacToeConsoleRunner.consoleIO.WriteLine(string.Empty);
            TicTacToeConsoleRunner.consoleIO.WriteHorizontalSeparator();
            string userInput = this.CurrentPlayer.AskForUserInput();
            return userInput;
        }

        private void SetNextPlayer()
        {
            CurrentPlayer = this.TicTacToeConsoleRunner.Players.First(p => p!= CurrentPlayer);
        }

        private bool HasToChangeState()
        {
            return this.TicTacToeConsoleRunner.board.State != TicTacToeBoardState.Playing;
        }

        private void SetNextState()
        {   
            if ( TicTacToeConsoleRunner.board.State == TicTacToeBoardState.Draw)
            {
                this.TicTacToeConsoleRunner.State = new DrawState(this);
            }
            else
            {
                if (TicTacToeConsoleRunner.board.Winner == TicTacToeConsoleRunner.Players[1].Mark)
                    this.TicTacToeConsoleRunner.State = new HumanWinsState(this);
                else
                    this.TicTacToeConsoleRunner.State = new AIWinsState(this);
            }
        }

        private void WriteInfoFromPreviousStep()
        {   
            TicTacToeConsoleRunner.consoleIO.WriteLine(InfoFromPreviousStep);
        }

        private void DrawBoard()
        {
            TicTacToeConsoleRunner.DrawBoard();
        }
    }
}