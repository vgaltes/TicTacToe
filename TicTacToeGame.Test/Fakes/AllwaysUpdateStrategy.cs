using TicTacToeGame.Models;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Fakes
{
    public class AllwaysUpdateStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Board board)
        {
            return true;
        }

        public void Update(Board board)
        {
            board.FillAICell(new CellCoordinates(0, 0));
        }
    }
}