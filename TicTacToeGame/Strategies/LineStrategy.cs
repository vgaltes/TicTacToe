using System.Collections.Generic;
using System.Linq;

namespace TicTacToeGame.Strategies
{
    public abstract class LineStrategy : TicTacToeStrategy
    {
        protected List<Line> Lines = new List<Line>();
        private Cell cellTypeToEvaluate;

        public LineStrategy(Cell cellTypeToEvaluate)
        {
            this.cellTypeToEvaluate = cellTypeToEvaluate;

            AddRows();

            AddColumns();

            AddDiagonals();
        }

        private void AddColumns()
        {
            Lines.Add(new Line(new MarkCoordinate(0, 0), new MarkCoordinate(1, 0), new MarkCoordinate(2, 0)));
            Lines.Add(new Line(new MarkCoordinate(0, 1), new MarkCoordinate(1, 1), new MarkCoordinate(2, 1)));
            Lines.Add(new Line(new MarkCoordinate(0, 2), new MarkCoordinate(1, 2), new MarkCoordinate(2, 2)));
        }

        private void AddRows()
        {
            Lines.Add(new Line(new MarkCoordinate(0, 0), new MarkCoordinate(0, 1), new MarkCoordinate(0, 2)));
            Lines.Add(new Line(new MarkCoordinate(1, 0), new MarkCoordinate(1, 1), new MarkCoordinate(1, 2)));
            Lines.Add(new Line(new MarkCoordinate(2, 0), new MarkCoordinate(2, 1), new MarkCoordinate(2, 2)));
        }

        private void AddDiagonals()
        {
            Lines.Add(new Line(new MarkCoordinate(0, 0), new MarkCoordinate(1, 1), new MarkCoordinate(2, 2)));
            Lines.Add(new Line(new MarkCoordinate(0, 2), new MarkCoordinate(1, 1), new MarkCoordinate(2, 0)));
        }

        public virtual bool CanHandle(Board board)
        {
            foreach (var line in Lines)
            {
                if (LineHasTwoCellsOfEvaluatedType(board, line) && LineHasOneEmptyCell(board, line))
                    return true;
            }

            return false;
        }
        
        public virtual void Update(Board board)
        {
            foreach (var line in Lines)
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