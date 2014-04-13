using TicTacToeGame.Models;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Fakes
{
    public class FillFirstRowStrategy : TicTacToeStrategy
    {
        public const int FIRST_ROW = 0;

        public bool CanHandle(Board board)
        {
            return true;
        }

        public void Update(Board board)
        {
            for (var column = 0; column < board.NumberOfColumns; column ++  )
            {
                if (board.IsCellOfType(CellType.Empty, new CellCoordinates(FIRST_ROW, column)))
                {
                    board.FillAICell(new CellCoordinates(FIRST_ROW, column));
                    break;
                }
            }   
        }
    }
}