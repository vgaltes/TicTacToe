using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class ForkStrategy : TicTacToeStrategy
    {
        private const int MINIMUM_LINES_TO_FORK = 2;
        private const int AI_CELLS_IN_A_FORK_LINE = 2;
        private const int INVALID_COORDINATE = -1;

        public ForkStrategy(char myMark, char opponentsMark) : base(myMark, opponentsMark) { }

        public override bool CanHandle(Board board, char mark)
        {
            return GetCellCoordinatesSuitableForFork(board, mark) != INVALID_COORDINATE;
        }

        public override void Update(Board board, char mark)
        {
            board.FillCell(GetCellCoordinatesSuitableForFork(board, mark), mark);
        }

        private int GetCellCoordinatesSuitableForFork(Board board, char mark)
        {
            foreach (var emptyCell in board.EmptyCells)
            {
                int suitableLines = 0;

                var imaginaryBoard = board.GetCopyWithExtraCellOfType(mark, emptyCell);

                foreach (var line in board.Lines)
                {
                    if (IsLineSuitableForAFork(imaginaryBoard, line))
                        suitableLines++;
                }

                if (suitableLines >= MINIMUM_LINES_TO_FORK)
                    return emptyCell;
            }

            return INVALID_COORDINATE;
        }

        private bool IsLineSuitableForAFork(Board board, int[] line)
        {
            int aiCells = 0;

            foreach(var coordinate in line )
            {
                if(board.IsCellOfType(opponentsMark, coordinate))
                    return false;

                if (board.IsCellOfType(myMark, coordinate))
                    aiCells++;
            }

            return aiCells == AI_CELLS_IN_A_FORK_LINE;
        }
    }
}