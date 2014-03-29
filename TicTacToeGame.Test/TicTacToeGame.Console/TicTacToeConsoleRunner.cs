namespace TicTacToeGame.Console
{
    public class TicTacToeConsoleRunner
    {
        private readonly TicTacToe ticTacToe;

        public TicTacToeConsoleRunner(TicTacToe ticTacToe)
        {
            this.ticTacToe = ticTacToe;
        }

        public void Play(int row, int column)
        {
            ticTacToe.OpponentMove(row, column);
            ticTacToe.AIMove();
        }

        public Cell[,] GetBoard()
        {
            return ticTacToe.Board;
        }
    }
}