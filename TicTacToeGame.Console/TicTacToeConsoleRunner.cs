namespace TicTacToeGame.Console
{
    public class TicTacToeConsoleRunner
    {
        private readonly TicTacToe ticTacToe;

        public TicTacToeConsoleRunner(TicTacToe ticTacToe)
        {
            this.ticTacToe = ticTacToe;
            //ticTacToe.AIMove();
        }

        public void Play(int row, int column)
        {
            ticTacToe.OpponentMove(row, column);
            ticTacToe.AIMove();
        }

        public Board GetBoard()
        {
            return ticTacToe.Board;
        }
    }
}