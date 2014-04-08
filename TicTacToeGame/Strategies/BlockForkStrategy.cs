using System;
using System.Collections.Generic;

namespace TicTacToeGame.Strategies
{
    public class BlockForkStrategy : LineStrategy
    {
        public BlockForkStrategy() : base(Cell.AI) { }

        public override bool CanHandle(Board board)
        {
            foreach (var emptyCell in board.EmptyCells)
            {
                var imaginaryBoard = board.GetCopyWithExtraCellOfType(Cell.AI, emptyCell.Row, emptyCell.Column);

                foreach (var line in Lines)
                {
                    if (IsLineSuitableForABlockFork(imaginaryBoard, line))
                        return true;
                }
            }

            return false;
        }

        public override void Update(Board board)
        {
            foreach (var emptyCell in board.EmptyCells)
            {
                var imaginaryBoard = board.GetCopyWithExtraCellOfType(Cell.AI, emptyCell.Row, emptyCell.Column);

                foreach (var line in Lines)
                {
                    if (IsLineSuitableForABlockFork(imaginaryBoard, line))
                    {
                        board.FillAICell(emptyCell.Row, emptyCell.Column);
                        return;
                    }
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

        private bool IsLineSuitableForABlockFork(Board board, Line line)
        {
            int aiCells = 0;

            foreach (var coordinate in line.Coordinates)
            {
                if ( board.IsCellOfType(Cell.Opponent, coordinate.Row, coordinate.Column))
                    return false;

                if ( board.IsCellOfType(Cell.AI, coordinate.Row, coordinate.Column))
                    aiCells++;
            }

            return aiCells == 2;
        }
    }
}