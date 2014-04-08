using System;
using System.Collections.Generic;

namespace TicTacToeGame.Strategies
{
    public class BlockForkStrategy : LineStrategy
    {
        public BlockForkStrategy() : base(Cell.AI) { }

        public bool CanHandle(Cell[,] board)
        {
            foreach (var emptyCell in EmptyCellsInBoard(board))
            {
                var imaginaryBoard = new Cell[3, 3];
                Array.Copy(board, imaginaryBoard, board.Length);
                imaginaryBoard[emptyCell.Row, emptyCell.Column] = Cell.AI;

                foreach (var line in Lines)
                {
                    if (IsLineSuitableForABlockFork(imaginaryBoard, line))
                        return true;
                }
            }

            return false;
        }

        public void Update(Cell[,] board)
        {
            throw new NotImplementedException();
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

        private bool IsLineSuitableForABlockFork(Cell[,] board, Line line)
        {
            int aiCells = 0;

            foreach (var coordinate in line.Coordinates)
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