using System;
using System.Collections;
using System.Collections.Generic;
namespace TicTacToeGame.Strategies
{
    public class ForkStrategy : LineStrategy
    {
        public ForkStrategy() : base(Cell.AI) { }

        public new bool CanHandle(Cell[,] board)
        {
            int suitableLines = 0;

            foreach (var emptyCell in EmptyCellsInBoard(board))
            {
                foreach (var line in LinesWhichCrossesTheCell(emptyCell))
                {
                    if (IsLineSuitableForAFork(board, line))
                        suitableLines++;
                }
            }

            return suitableLines >= 2;
        }

        private IEnumerable<MarkCoordinate> EmptyCellsInBoard(Cell[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (board[row, column] == Cell.Empty)
                    {
                        yield return new MarkCoordinate(row, column);
                    }
                }
            }
        }

        private IEnumerable<Line> LinesWhichCrossesTheCell(MarkCoordinate cell)
        {
            foreach (var line in Lines)
            {
                if (line.LineStart.Row == cell.Row && line.LineStart.Column == cell.Column ||
                    line.LineEnd.Row == cell.Row && line.LineEnd.Column == cell.Column ||
                    line.Evaluate.Row == cell.Row && line.Evaluate.Column == cell.Column)
                {
                    yield return line;
                }
            }
        }

        private bool IsLineSuitableForAFork(Cell[,] board, Line line)
        {
            int aiCells = 0;

            if (board[line.LineStart.Row, line.LineStart.Column] == Cell.Opponent ||
                board[line.LineEnd.Row, line.LineEnd.Column] == Cell.Opponent ||
                board[line.Evaluate.Row, line.Evaluate.Column] == Cell.Opponent)
                return false;

            if (board[line.LineStart.Row, line.LineStart.Column] == Cell.AI)
                aiCells++;
            if (board[line.LineEnd.Row, line.LineEnd.Column] == Cell.AI)
                aiCells++;
            if (board[line.Evaluate.Row, line.Evaluate.Column] == Cell.AI)
                aiCells++;

            return aiCells == 1;
        }
    }
}