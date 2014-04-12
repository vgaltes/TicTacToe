using System;
using System.Collections.Generic;
using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class BlockForkStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Board board)
        {
            foreach (var emptyCell in board.EmptyCells)
            {
                var imaginaryBoard = board.GetCopyWithExtraCellOfType(CellType.AI, emptyCell);

                foreach (var line in board.Lines)
                {
                    if (IsLineSuitableForABlockFork(imaginaryBoard, line))
                        return true;
                }
            }

            return false;
        }

        public void Update(Board board)
        {
            foreach (var emptyCell in board.EmptyCells)
            {
                var imaginaryBoard = board.GetCopyWithExtraCellOfType(CellType.AI, emptyCell);

                foreach (var line in board.Lines)
                {
                    if (IsLineSuitableForABlockFork(imaginaryBoard, line))
                    {
                        board.FillAICell(emptyCell);
                        return;
                    }
                }
            }
        }

        private bool IsLineSuitableForABlockFork(Board board, Line line)
        {
            int aiCells = 0;

            foreach (var coordinate in line.Coordinates)
            {
                if ( board.IsCellOfType(CellType.Opponent, coordinate))
                    return false;

                if ( board.IsCellOfType(CellType.AI, coordinate))
                    aiCells++;
            }

            return aiCells == 2;
        }
    }
}