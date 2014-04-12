using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class BlockForkStrategy : TicTacToeStrategy
    {
        private const int MINIMUM_OPPONENT_CELLS_TO_BLOCK_FORK = 2;
        public bool CanHandle(Board board)
        {
            if (board.HasLessOpponentCellsThan(MINIMUM_OPPONENT_CELLS_TO_BLOCK_FORK))
                return false;

            return GetCellCoordinatesSuitableForBlockFork(board).IsValid;
        }

        public void Update(Board board)
        {
            board.FillAICell(GetCellCoordinatesSuitableForBlockFork(board));            
        }

        private CellCoordinates GetCellCoordinatesSuitableForBlockFork(Board board)
        {
            foreach (var emptyCell in board.EmptyCells)
            {
                var imaginaryBoard = board.GetCopyWithExtraCellOfType(CellType.AI, emptyCell);

                var winStrategy = new WinStrategy();
                if (winStrategy.CanHandle(imaginaryBoard))
                {
                    return emptyCell;
                }
            }

            return CellCoordinates.InvalidCoordinates;
        }
    }
}