using System.Collections.Generic;
using TicTacToeGame.Models;
namespace TicTacToeGame.Test
{
    public static class BoardTestHelper
    {
        public static Board GetAnEmptyBoard()
        {
            return GetABoardWithAMarkInTheCenterOfType(CellType.Empty);
        }

        public static Board GetABoardWithAMarkInTheCenterOfType(CellType cell)
        {
            return GetABoardWithAMark(new Mark(cell, new MarkCoordinate(1,1)));
        }

        public static Board GetABoardWithAMark(Mark mark)
        {
            return GetABoardWithMarks(new List<Mark> { mark });
        }

        internal static Board GetABoardWithMarks(List<Mark> marks)
        {
            var board = new Board();

            foreach (var mark in marks)
            {
                board.FillCellWithType(mark.Cell, mark.CellCoordinate);
            }

            return board;
        }

        internal static Board GetAFullBoard()
        {
            var board = new Board();
            foreach( var emptyCell in board.EmptyCells)
            {
                board.FillAICell(emptyCell);
            }

            return board;
        }

        internal static Board GetAFullBoardWithAnEmptyCellAt(int row, int column)
        {
            var board = GetAFullBoard();

            board.FillCellWithType(CellType.Empty, new MarkCoordinate(row, column));

            return board;
        }
    }
}