using System;
using System.Collections.Generic;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Console.Players
{
    public class AIPlayer : Player
    {
        private readonly ConsoleIO consoleIO;
        private readonly List<TicTacToeStrategy> strategies;

        public AIPlayer(ConsoleIO consoleIO, List<TicTacToeStrategy> strategies, char mark)
        {
            this.consoleIO = consoleIO;
            this.strategies = strategies;
            this.Mark = mark;
        }

        public void Move(Board board, string userInput)
        {
            foreach (var strategy in strategies)
            {
                if (strategy.CanHandle(board, Mark))
                {
                    strategy.Update(board, Mark);
                    break;
                }
            }
        }

        public string AskForUserInput()
        {
            consoleIO.WriteLine(Resources.AIIsGonnaMove);
            consoleIO.WriteLine(string.Empty);
            consoleIO.WritePrompt();
            return consoleIO.ReadLine();
        }

        public char Mark { get; set; }
    }
}