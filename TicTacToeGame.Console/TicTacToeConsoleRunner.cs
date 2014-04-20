using System;
using System.Linq;
using System.Text.RegularExpressions;
using TicTacToeGame.Console.States;
using TicTacToeGame.Exceptions;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console
{
    public class TicTacToeConsoleRunner
    {
        private const string AI_PLAYER = "1";
        private const string HUMAN_PLAYER = "2";
        private const string QUIT_COMMAND = "q!";

        public readonly ITicTacToe ticTacToe;
        public readonly TicTacToeBoardDrawer ticTacToeBoardDrawer;
        public readonly ConsoleIO consoleIO;

        private string extraInfo = string.Empty;

        public TicTacToeConsoleRunnerState State { get; set; }

        public TicTacToeConsoleRunner(ITicTacToe ticTacToe, TicTacToeBoardDrawer ticTacToeBoardDrawer, ConsoleIO consoleIO)
        {
            this.ticTacToe = ticTacToe;
            this.ticTacToeBoardDrawer = ticTacToeBoardDrawer;
            this.consoleIO = consoleIO;

            this.State = new AskingForPlayerState(this);
        }

        public void Run()
        {
            /*
            SetInitialPlayer();
            DrawBoard();

            var userInput = GetUserInput();

            while (userInput != QUIT_COMMAND)
            {
                if (ticTacToe.State == TicTacToeState.Playing)
                {
                    PlayGame(userInput);
                }

                DrawBoard();

                if (ticTacToe.State != TicTacToeState.Playing)
                {
                    ResetGame();
                }

                userInput = consoleIO.ReadLine();
            }*/

            while ( !State.IsFinished)
            {
                State.Evaluate();
            }
        }

        private void SetInitialPlayer()
        {
            consoleIO.Clear();
            consoleIO.WriteLine(Resources.SelectPlayer);
            var option = consoleIO.ReadLine();
            if (option != AI_PLAYER && option != HUMAN_PLAYER)
                SetInitialPlayer();
            else
            {
                var initialPlayer = (CellType)Enum.Parse(typeof(CellType), option);
                ticTacToe.SetInitialPlayer(initialPlayer);
                extraInfo = Resources.WriteCoordinates;
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

            do
            {
                line = consoleIO.ReadLine();
            } while (!IsValidInput(line));

            return line;
        }

        private bool IsValidInput(string line)
        {
            string regexExpression = string.Format("[\\d],[\\d]", ticTacToe.Board.Size - 1);

            if (line == QUIT_COMMAND)
                return true;
            else
                return Regex.IsMatch(line, regexExpression)
                && CoordinatesAreValidIntegers(line)
                && CoordinatesInRange(line);
        }

        private bool CoordinatesAreValidIntegers(string line)
        {
            string[] coordinates = line.Split(',');
            int[] intCoordinates = new int[2];
            bool rowValid = int.TryParse(coordinates[0], out intCoordinates[0]);
            bool columnValid = int.TryParse(coordinates[1], out intCoordinates[1]);

            return rowValid && columnValid;
        }

        private bool CoordinatesInRange(string line)
        {
            string[] coordinates = line.Split(',');
            int row, column;
            row = int.Parse(coordinates[0]);
            column = int.Parse(coordinates[1]);

            return row < ticTacToe.Board.Size && column < ticTacToe.Board.Size;
        }

        private void PlayGame(string userInput)
        {
            try
            {
                extraInfo = Resources.WriteCoordinates;
                ticTacToe.OpponentMove(GetCoordinatesFromUserInput(userInput));
            }
            catch (NotAllowedMovementException)
            {
                extraInfo = string.Format("{0}\n{1}", Resources.NotAllowedMovement, Resources.WriteCoordinates);
            }
        }

        private static CellCoordinates GetCoordinatesFromUserInput(string userInput)
        {
            int[] coordinates = userInput.Split(',').Select(c => int.Parse(c)).ToArray();
            return new CellCoordinates(coordinates[0], coordinates[1]);
        }

        private void ResetGame()
        {
            consoleIO.ReadKey();
            ticTacToe.Reset();
            SetInitialPlayer();
            DrawBoard();
        }
    }
}
