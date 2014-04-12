using TicTacToeGame.Models;
namespace TicTacToeGame.Console
{
    public class TicTacToeConsoleRunner
    {
        private readonly ITicTacToe ticTacToe;

        public TicTacToeConsoleRunner(ITicTacToe ticTacToe)
        {
            this.ticTacToe = ticTacToe;
            //ticTacToe.AIMove();
        }

        public void Play(CellCoordinates cellCoordinate)
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