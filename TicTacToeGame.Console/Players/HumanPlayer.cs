using System;

namespace TicTacToeGame.Console.Players
{
    public class HumanPlayer : Player
    {
        ConsoleIO consoleIO;

        public HumanPlayer(ConsoleIO consoleIO)
        {
            this.consoleIO = consoleIO;
        }

        public void Move(string userInput)
        {
            throw new NotImplementedException();
        }

        public string AskForUserInput()
        {
            consoleIO.WriteLine(Resources.WriteCoordinates);
            return consoleIO.ReadLine();
        }
    }
}