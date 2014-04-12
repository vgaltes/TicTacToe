using System;
using System.Collections.Generic;
using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class BlockForkStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Board board)
        {
            return GetCellCoordinatesSuitableForBlockFork(board).IsValid;
        }

        public void Update(Board board)
        {

            board.FillAICell(GetCellCoordinatesSuitableForBlockFork(board));            
        }

        private CellCoordinates GetCellCoordinatesSuitableForBlockFork(Board board)
        {
            foreach (var emptyCell in board.EmptyCells)
            {
                var imaginaryBoard = board.GetCopyWithExtraCellOfType(CellType.AI, emptyCell);

                var winStrategy = new WinStrategy();
                if ( winStrategy.CanHandle(board) )
                {
                    return emptyCell;
                }
            }

            return CellCoordinates.InvalidCoordinates;
        }
    }
}