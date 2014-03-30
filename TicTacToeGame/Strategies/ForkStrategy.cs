using System;
using System.Collections;
using System.Collections.Generic;
namespace TicTacToeGame.Strategies
{
    public class ForkStrategy : LineStrategy
    {
        public ForkStrategy() : base(Cell.AI) { }

        public override bool CanHandle(Cell[,] board)
        {
            
            foreach (var emptyCell in EmptyCellsInBoard(board))
            {
                int suitableLines = 0;

                //foreach (var line in LinesWhichCrossesTheCell(emptyCell))
                //{
                var imaginaryBoard = new Cell[3, 3];
                // Buffer.BlockCopy(board, 0, imaginaryBoard, 0, board.Length * sizeof(Cell));
                Array.Copy(board, imaginaryBoard, board.Length);
                imaginaryBoard[emptyCell.Row, emptyCell.Column] = Cell.AI;

                foreach (var line in Lines)
                {
                    if (IsLineSuitableForAFork(imaginaryBoard, line))
                        suitableLines++;
                }
                //}

                return suitableLines >= 2;
            }

            return false;
        }

        public override void Update(Cell[,] board)
        {
            
            foreach (var emptyCell in EmptyCellsInBoard(board))
            {
                int suitableLines = 0;

                //foreach (var line in LinesWhichCrossesTheCell(emptyCell))
                //{
                var imaginaryBoard = new Cell[3, 3];
                Buffer.BlockCopy(board, 0, imaginaryBoard, 0, board.Length * sizeof(Cell));
                imaginaryBoard[emptyCell.Row, emptyCell.Column] = Cell.AI;

                foreach ( var line in Lines)
                { 
                    if (IsLineSuitableForAFork(imaginaryBoard, line))
                            suitableLines++;
                }
                //}

                if (suitableLines >= 2)
                    board[emptyCell.Row, emptyCell.Column] = Cell.AI;
            }
            
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
                if (line.FirstPoint.Row == cell.Row && line.FirstPoint.Column == cell.Column ||
                    line.SecondPoint.Row == cell.Row && line.SecondPoint.Column == cell.Column ||
                    line.ThirdPoint.Row == cell.Row && line.ThirdPoint.Column == cell.Column)
                {
                    yield return line;
                }
            }
        }

        private bool IsLineSuitableForAFork(Cell[,] board, Line line)
        {
            int aiCells = 0;

            if (board[line.FirstPoint.Row, line.FirstPoint.Column] == Cell.Opponent ||
                board[line.SecondPoint.Row, line.SecondPoint.Column] == Cell.Opponent ||
                board[line.ThirdPoint.Row, line.ThirdPoint.Column] == Cell.Opponent)
                return false;

            if (board[line.FirstPoint.Row, line.FirstPoint.Column] == Cell.AI)
                aiCells++;
            if (board[line.SecondPoint.Row, line.SecondPoint.Column] == Cell.AI)
                aiCells++;
            if (board[line.ThirdPoint.Row, line.ThirdPoint.Column] == Cell.AI)
                aiCells++;

            return aiCells == 1;
        }
    }
}