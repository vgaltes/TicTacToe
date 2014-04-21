namespace TicTacToeGame.Console.Players
{
    public interface Player
    {
        void Move(string userInput);

        string AskForUserInput();
    }
}