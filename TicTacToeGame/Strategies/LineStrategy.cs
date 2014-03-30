using System.Collections.Generic;
namespace TicTacToeGame.Strategies
{
    public abstract class LineStrategy : TicTacToeStrategy
    {
        List<Line> Lines = new List<Line>();
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

        public bool CanHandle(Cell[,] board)
        {
            foreach (var line in Lines)
            {
                if (board[line.LineStart.Row, line.LineStart.Column] == cellTypeToEvaluate &&
                     board[line.LineEnd.Row, line.LineEnd.Column] == cellTypeToEvaluate &&
                     board[line.Evaluate.Row, line.Evaluate.Column] == Cell.Empty
                    )
                    return true;
            }

            return false;
        }

        public void Update(Cell[,] board)
        {
            foreach (var line in Lines)
            {
                if (board[line.LineStart.Row, line.LineStart.Column] == cellTypeToEvaluate &&
                     board[line.LineEnd.Row, line.LineEnd.Column] == cellTypeToEvaluate &&
                     board[line.Evaluate.Row, line.Evaluate.Column] == Cell.Empty
                    )
                {
                    board[line.Evaluate.Row, line.Evaluate.Column] = Cell.AI;
                }
            }
        }
    }
}