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

                var imaginaryBoard = new Cell[3, 3];
                Array.Copy(board, imaginaryBoard, board.Length);
                imaginaryBoard[emptyCell.Row, emptyCell.Column] = Cell.AI;

                foreach (var line in Lines)
                {
                    if (IsLineSuitableForAFork(imaginaryBoard, line))
                        suitableLines++;
                }

                if (suitableLines >= 2)
                    return true;
            }

            return false;
        }

        public override void Update(Cell[,] board)
        {
            
            foreach (var emptyCell in EmptyCellsInBoard(board))
            {
                int suitableLines = 0;

                var imaginaryBoard = new Cell[3, 3];
                Array.Copy(board, imaginaryBoard, board.Length);
                imaginaryBoard[emptyCell.Row, emptyCell.Column] = Cell.AI;

                foreach ( var line in Lines)
                { 
                    if (IsLineSuitableForAFork(imaginaryBoard, line))
                            suitableLines++;
                }

                if (suitableLines >= 2)
                {
                    board[emptyCell.Row, emptyCell.Column] = Cell.AI;
                    return;
                }
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
                foreach ( var coordinate in line.Coordinates )
                {
                    if (coordinate.Row == cell.Row && coordinate.Column == cell.Column)
                        yield return line;
                }
            }
        }

        private bool IsLineSuitableForAFork(Cell[,] board, Line line)
        {
            int aiCells = 0;

            foreach(var coordinate in line.Coordinates )
            {
                if (board[coordinate.Row, coordinate.Column] == Cell.Opponent)
                    return false;

                if (board[coordinate.Row, coordinate.Column] == Cell.AI)
                    aiCells++;
            }

            return aiCells == 2;
        }
    }
}