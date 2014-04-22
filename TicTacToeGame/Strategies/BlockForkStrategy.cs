using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class BlockForkStrategy : TicTacToeStrategy
    {
        private const int MINIMUM_OPPONENT_CELLS_TO_BLOCK_FORK = 2;
        private const int INVALID_COORDINATE = -1;

        public BlockForkStrategy(char myMark, char opponentsMark) : base(myMark, opponentsMark) { }

        public override bool CanHandle(Board board, char mark)
        {
            if (board.HasLessCellsOfTypeThan(opponentsMark, MINIMUM_OPPONENT_CELLS_TO_BLOCK_FORK))
                return false;

            return GetCellCoordinatesSuitableForBlockFork(board, mark) != INVALID_COORDINATE;
        }

        public override void Update(Board board, char mark)
        {
            board.FillCell(GetCellCoordinatesSuitableForBlockFork(board, mark), mark);
        }

        private int GetCellCoordinatesSuitableForBlockFork(Board board, char mark)
        {
            foreach (var emptyCell in board.EmptyCells)
            {
                var imaginaryBoard = board.GetCopyWithExtraCellOfType(mark, emptyCell);

                var winStrategy = new WinStrategy(myMark, opponentsMark);
                if (winStrategy.CanHandle(imaginaryBoard, mark))
                {
                    return emptyCell;
                }
            }

            return INVALID_COORDINATE;
        }
    }
}