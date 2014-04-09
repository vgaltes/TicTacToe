using System.Collections.Generic;
using System.Linq;

namespace TicTacToeGame.Strategies
{
    public abstract class EvaluatedLineStrategy : TicTacToeStrategy
    {
        private Cell cellTypeToEvaluate;

        public EvaluatedLineStrategy(Cell cellTypeToEvaluate)
        {
            this.cellTypeToEvaluate = cellTypeToEvaluate;
        }
                
        public virtual bool CanHandle(Board board)
        {
            foreach (var line in board.Lines)
            {
                if (LineHasTwoCellsOfEvaluatedType(board, line) && LineHasOneEmptyCell(board, line))
                    return true;
            }

            return false;
        }
        
        public virtual void Update(Board board)
        {
            foreach (var line in board.Lines)
            {
                if (LineHasTwoCellsOfEvaluatedType(board, line) && LineHasOneEmptyCell(board, line))
                {
                    FillEmptyCellWithAIMark(board, line);
                }
            }
        }

        private void FillEmptyCellWithAIMark(Board board, Line line)
        {
            foreach(var coordinate in line.Coordinates)
            {
                FillMarkCoordinateIfEmpty(board, coordinate);
            }
        }

        private void FillMarkCoordinateIfEmpty(Board board, MarkCoordinate coordinate)
        {
            if ( board.IsCellOfType(Cell.Empty, coordinate.Row, coordinate.Column))
            {
                board.FillAICell(coordinate.Row, coordinate.Column);
            }
        }

        protected bool LineHasTwoCellsOfEvaluatedType(Board board, Line line)
        {
            int cellCount = board.CountCellsOfTypeInLine(cellTypeToEvaluate, line);
            return cellCount == 2;
        }

        protected bool LineHasOneEmptyCell(Board board, Line line)
        {
            int cellCount = board.CountCellsOfTypeInLine(Cell.Empty, line);
            return cellCount == 1;
        }

        private int CountCellsOfType(Cell cellType, Board board, Line line)
        {
            return board.CountCellsOfTypeInLine(cellType, line);
        }
    }
}