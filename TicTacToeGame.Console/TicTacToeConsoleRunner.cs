using TicTacToeGame.Console.States;

namespace TicTacToeGame.Console
{
    public class TicTacToeConsoleRunner
    {
        public readonly ITicTacToe ticTacToe;
        public readonly TicTacToeBoardDrawer ticTacToeBoardDrawer;
        public readonly ConsoleIO consoleIO;

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
            while ( !State.IsFinished)
            {
                State.Evaluate();
            }
        }
    }
}