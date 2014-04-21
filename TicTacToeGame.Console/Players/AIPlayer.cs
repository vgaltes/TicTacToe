using System;

namespace TicTacToeGame.Console.Players
{
    public class AIPlayer : Player
    {
        private ConsoleIO consoleIO;
        private ITicTacToe ticTacToe;

        public AIPlayer(ConsoleIO consoleIO, ITicTacToe ticTacToe)
        {
            this.consoleIO = consoleIO;
            this.ticTacToe = ticTacToe;
        }

        public void Move(string userInput)
        {
            throw new NotImplementedException();
        }

        public string AskForUserInput()
        {
            throw new NotImplementedException();
        }
    }
}