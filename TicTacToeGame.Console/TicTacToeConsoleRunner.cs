using TicTacToeGame.Models;
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

        public void Play(MarkCoordinate cellCoordinate)
        {
            ticTacToe.OpponentMove(cellCoordinate);
            ticTacToe.AIMove();
        }

        public Board GetBoard()
        {
            return ticTacToe.Board;
        }
    }
}