namespace TicTacToeGame.Console.Players
{
    public interface Player
    {
        void Move(Board board, string userInput);

        string AskForUserInput();

        char Mark { get; set; }
    }
}