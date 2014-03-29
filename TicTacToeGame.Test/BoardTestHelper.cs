using System.Collections.Generic;
namespace TicTacToeGame.Test
{
    public static class BoardTestHelper
    {
        public static Cell[,] GetAnEmptyBoard()
        {
            return GetABoardWithAMarkInTheCenterOfType(Cell.Empty);
        }

        public static Cell[,] GetABoardWithAMarkInTheCenterOfType(Cell cell)
        {
            return GetABoardWithAMark(new Mark(1, 1, cell));
        }

        public static Cell[,] GetABoardWithAMark(Mark mark)
        {
            return GetABoardWithMarks(new List<Mark> { mark });
        }

        internal static Cell[,] GetABoardWithMarks(List<Mark> marks)
        {
            var board = new Cell[3, 3]{{Cell.Empty, Cell.Empty, Cell.Empty},
                                                {Cell.Empty, Cell.Empty, Cell.Empty},
                                                {Cell.Empty, Cell.Empty, Cell.Empty}};

            foreach (var mark in marks)
            {
                board[mark.Row, mark.Column] = mark.Cell;
            }

            return board;
        }

        internal static Cell[,] GetAFullBoard()
        {
            var board = new Cell[3, 3]{{Cell.AI, Cell.AI, Cell.AI},
                                        {Cell.AI, Cell.AI, Cell.AI},
                                        {Cell.AI, Cell.AI, Cell.AI}};

            return board;
        }

        internal static Cell[,] GetAFullBoardWithAnEmptyCellAt(int row, int column)
        {
            var board = GetAFullBoard();

            board[row, column] = Cell.Empty;

            return board;
        }
    }
}