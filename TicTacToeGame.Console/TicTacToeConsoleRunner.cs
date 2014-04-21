using TicTacToeGame.Console.Players;
using TicTacToeGame.Console.States;

namespace TicTacToeGame.Console
{
    public class TicTacToeConsoleRunner
    {
        public readonly ITicTacToe ticTacToe;
        public readonly TicTacToeBoardDrawer ticTacToeBoardDrawer;
        public readonly ConsoleIO consoleIO;
        public readonly Player player1;
        public readonly Player player2;

        public TicTacToeConsoleRunnerState State { get; set; }

        public TicTacToeConsoleRunner(ITicTacToe ticTacToe, 
            TicTacToeBoardDrawer ticTacToeBoardDrawer, ConsoleIO consoleIO,
            Player player1, Player player2)
        {
            this.ticTacToe = ticTacToe;
            this.ticTacToeBoardDrawer = ticTacToeBoardDrawer;
            this.consoleIO = consoleIO;
            this.player1 = player1;
            this.player2 = player2;

            this.State = new AskingForPlayerState(this);
        }

        public void Run()
        {
            while ( !State.IsFinished)
            {
                State.Evaluate();
            }
        }
    }
}