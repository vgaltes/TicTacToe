using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public abstract class EvaluateLineStrategy : TicTacToeStrategy
    {
        private char markToEvaluate;

        public EvaluateLineStrategy(char markToEvaluate) : base(markToEvaluate, ' ')
        {
            this.markToEvaluate = markToEvaluate;
        }

        public override bool CanHandle(Board board, char mark)
        {
            foreach (var line in board.Lines)
            {
                if (LineHasTwoCellsOfEvaluatedType(board, line) && LineHasOneEmptyCell(board, line))
                    return true;
            }

            return false;
        }

        public override void Update(Board board, char mark)
        {
            foreach (var line in board.Lines)
            {
                if (LineHasTwoCellsOfEvaluatedType(board, line) && LineHasOneEmptyCell(board, line))
                {
                    FillEmptyCellWithAIMark(board, line, mark);
                    return;
                }
            }
        }

        private void FillEmptyCellWithAIMark(Board board, int[] line, char mark)
        {
            foreach(var coordinate in line)
            {
                FillMarkCoordinateIfEmpty(board, coordinate, mark);
            }
        }

        private void FillMarkCoordinateIfEmpty(Board board, int cellCoordinate, char mark)
        {
            if ( board.IsCellEmpty(cellCoordinate))
            {
                board.FillCell(cellCoordinate, mark);
            }
        }

        protected bool LineHasTwoCellsOfEvaluatedType(Board board, int[] line)
        {
            int cellCount = board.CountCellsOfTypeInLine(markToEvaluate, line);
            return cellCount == 2;
        }

        protected bool LineHasOneEmptyCell(Board board, int[] line)
        {
            int cellCount = board.CountCellsOfTypeInLine(' ', line);
            return cellCount == 1;
        }
    }
}