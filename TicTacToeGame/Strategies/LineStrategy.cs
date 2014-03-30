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
            Lines.Add(new Line(new MarkCoordinate(2, 0), new MarkCoordinate(1, 0), new MarkCoordinate(0, 0)));
            Lines.Add(new Line(new MarkCoordinate(0, 1), new MarkCoordinate(1, 1), new MarkCoordinate(2, 1)));
            Lines.Add(new Line(new MarkCoordinate(2, 1), new MarkCoordinate(1, 1), new MarkCoordinate(0, 1)));
            Lines.Add(new Line(new MarkCoordinate(0, 2), new MarkCoordinate(1, 2), new MarkCoordinate(2, 2)));
            Lines.Add(new Line(new MarkCoordinate(2, 2), new MarkCoordinate(1, 2), new MarkCoordinate(0, 2)));
        }

        private void AddRows()
        {
            Lines.Add(new Line(new MarkCoordinate(0, 0), new MarkCoordinate(0, 1), new MarkCoordinate(0, 2)));
            Lines.Add(new Line(new MarkCoordinate(0, 2), new MarkCoordinate(0, 1), new MarkCoordinate(0, 0)));
            Lines.Add(new Line(new MarkCoordinate(1, 0), new MarkCoordinate(1, 1), new MarkCoordinate(1, 2)));
            Lines.Add(new Line(new MarkCoordinate(1, 2), new MarkCoordinate(1, 1), new MarkCoordinate(1, 0)));
            Lines.Add(new Line(new MarkCoordinate(2, 0), new MarkCoordinate(2, 1), new MarkCoordinate(2, 2)));
            Lines.Add(new Line(new MarkCoordinate(2, 2), new MarkCoordinate(2, 1), new MarkCoordinate(2, 0)));
        }

        private void AddDiagonals()
        {
            Lines.Add(new Line(new MarkCoordinate(0, 0), new MarkCoordinate(1, 1), new MarkCoordinate(2, 2)));
            Lines.Add(new Line(new MarkCoordinate(2, 2), new MarkCoordinate(1, 1), new MarkCoordinate(0, 0)));
            Lines.Add(new Line(new MarkCoordinate(0, 2), new MarkCoordinate(1, 1), new MarkCoordinate(2, 0)));
            Lines.Add(new Line(new MarkCoordinate(2, 0), new MarkCoordinate(1, 1), new MarkCoordinate(0, 2)));
        }

        public virtual bool CanHandle(Cell[,] board)
        {
            foreach (var line in Lines)
            {
                if (LineHasTwoCellsOfEvaluatedType(board, line) && LineHasOneEmptyCell(board, line))
                    return true;
            }

            return false;
        }
        
        public virtual void Update(Cell[,] board)
        {
            foreach (var line in Lines)
            {
                if (LineHasTwoCellsOfEvaluatedType(board, line) && LineHasOneEmptyCell(board, line))
                {
                    FillEmptyCellWithAIMark(board, line);
                }
            }
        }

        private void FillEmptyCellWithAIMark(Cell[,] board, Line line)
        {
            FillMarkCoordinateIfEmpty(board, line.LineStart);
            FillMarkCoordinateIfEmpty(board, line.LineEnd);
            FillMarkCoordinateIfEmpty(board, line.Evaluate);
        }

        private void FillMarkCoordinateIfEmpty(Cell[,] board, MarkCoordinate coordinate)
        {
            if (board[coordinate.Row, coordinate.Column] == Cell.Empty)
                board[coordinate.Row, coordinate.Column] = Cell.AI;
        }

        protected bool LineHasTwoCellsOfEvaluatedType(Cell[,] board, Line line)
        {
            int cellCount = CountCellsOfType(cellTypeToEvaluate, board, line);

            return cellCount == 2;
        }

        protected bool LineHasOneEmptyCell(Cell[,] board, Line line)
        {
            int cellCount = CountCellsOfType(Cell.Empty, board, line);

            return cellCount == 1;
        }

        private int CountCellsOfType(Cell cellType, Cell[,] board, Line line)
        {
            int cellCount = 0;

            if (board[line.LineStart.Row, line.LineStart.Column] == cellType)
                cellCount++;

            if (board[line.LineEnd.Row, line.LineEnd.Column] == cellType)
                cellCount++;

            if (board[line.Evaluate.Row, line.Evaluate.Column] == cellType)
                cellCount++;

            return cellCount;
        }
    }
}