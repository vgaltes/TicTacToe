using System;

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
            throw new NotImplementedException();
        }

        public string AskForUserInput()
        {
            consoleIO.WriteLine(Resources.WriteCoordinates);
            return consoleIO.ReadLine();
        }
    }
}