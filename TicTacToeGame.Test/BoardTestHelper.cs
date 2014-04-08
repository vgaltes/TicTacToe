using System.Collections.Generic;
namespace TicTacToeGame.Test
{
    public static class BoardTestHelper
    {
        public static Board GetAnEmptyBoard()
        {
            return GetABoardWithAMarkInTheCenterOfType(Cell.Empty);
        }

        public static Board GetABoardWithAMarkInTheCenterOfType(Cell cell)
        {
            return GetABoardWithAMark(new Mark(1, 1, cell));
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
                board.FillCellWithType(mark.Cell, mark.Row, mark.Column);
            }

            return board;
        }

        internal static Board GetAFullBoard()
        {
            var board = new Board();
            foreach( var emptyCell in board.EmptyCells)
            {
                board.FillAICell(emptyCell.Row, emptyCell.Column);
            }

            return board;
        }

        internal static Board GetAFullBoardWithAnEmptyCellAt(int row, int column)
        {
            var board = GetAFullBoard();

            board.FillCellWithType(Cell.Empty, row, column);

            return board;
        }
    }
}