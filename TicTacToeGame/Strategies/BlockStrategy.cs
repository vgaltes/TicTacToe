using System;
using System.Collections.Generic;

namespace TicTacToeGame.Strategies
{
    public class Line
    {
        public MarkCoordinate LineStart { get; private set; }
        public MarkCoordinate LineEnd { get; private set; }
        public MarkCoordinate Evaluate { get; private set; }

        public Line(MarkCoordinate start, MarkCoordinate middle, MarkCoordinate end)
        {
            LineStart = start;
            LineEnd = middle;
            Evaluate = end;
        }
    }

    public class BlockStrategy : TicTacToeStrategy
    {
        List<Line> Lines = new List<Line>();

        public BlockStrategy()
        {
            AddRows();

            AddColumns();
        }

        private void AddColumns()
        {
            Lines.Add(new Line(new MarkCoordinate(0, 0), new MarkCoordinate(1, 0), new MarkCoordinate(2, 0)));
            Lines.Add(new Line(new MarkCoordinate(2, 0), new MarkCoordinate(1, 0), new MarkCoordinate(0, 0)));
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

        public bool CanHandle(Cell[,] board)
        {
            foreach (var line in Lines)
            {
                if (board[line.LineStart.Row, line.LineStart.Column] == Cell.Opponent &&
                     board[line.LineEnd.Row, line.LineEnd.Column] == Cell.Opponent &&
                     board[line.Evaluate.Row, line.Evaluate.Column] == Cell.Empty
                    )
                    return true;
            }

            return false;
        }

        public void Update(Cell[,] board)
        {
            throw new NotImplementedException();
        }
    }
}
