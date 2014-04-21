using System;
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

        private Dictionary<TicTacToeState, Type> nextStates;

        private Player currentPlayer;

        public PlayingState(TicTacToeConsoleRunnerState state)
        {
            this.TicTacToeConsoleRunner = state.TicTacToeConsoleRunner;
            this.currentPlayer = state.TicTacToeConsoleRunner.player1;
            SetNextStates();
        }

        public PlayingState(TicTacToeConsoleRunner tttConsoleRunner)
        {
            this.TicTacToeConsoleRunner = tttConsoleRunner;
            this.currentPlayer = tttConsoleRunner.player1;
            SetNextStates();
        }

        public override void Evaluate()
        {
            TicTacToeConsoleRunner.DrawHeader();
            WriteInfoFromPreviousStep();

            DrawBoard();

            TicTacToeConsoleRunner.consoleIO.WriteLine(string.Empty);
            TicTacToeConsoleRunner.consoleIO.WriteHorizontalSeparator();
            string userInput = this.currentPlayer.AskForUserInput();

            if (userInput == QUIT_COMMAND)
            {
                this.TicTacToeConsoleRunner.State = new QuitGameState(this);
            }
            else
            {
                try
                {
                    this.currentPlayer.Move(userInput);
                    if (HasToChangeState())
                    {
                        SetNextState();
                    }
                    else
                    {
                        SetNextPlayer();
                    }
                }
                catch (NotAllowedMovementException)
                {
                    this.InfoFromPreviousStep = Resources.NotAllowedMovement;
                }
            }
        }

        private void SetNextPlayer()
        {
            if (currentPlayer == this.TicTacToeConsoleRunner.player1)
                currentPlayer = this.TicTacToeConsoleRunner.player2;
            else
                currentPlayer = this.TicTacToeConsoleRunner.player1;
        }

        private bool HasToChangeState()
        {
            return nextStates.ContainsKey(this.TicTacToeConsoleRunner.ticTacToe.State);
        }

        private void SetNextState()
        {
            Type nextState = nextStates[this.TicTacToeConsoleRunner.ticTacToe.State];
            ConstructorInfo constructorInfo = nextState.GetConstructor(new[] { typeof(TicTacToeConsoleRunnerState) });
            this.TicTacToeConsoleRunner.State =
                (TicTacToeConsoleRunnerState)constructorInfo.Invoke(new object[] { this });
        }

        private void SetNextStates()
        {
            nextStates = new Dictionary<TicTacToeState, Type>();
            nextStates.Add(TicTacToeState.AIWins, typeof(AIWinsState));
            nextStates.Add(TicTacToeState.OpponentWins, typeof(HumanWinsState));
            nextStates.Add(TicTacToeState.Draw, typeof(DrawState));
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
