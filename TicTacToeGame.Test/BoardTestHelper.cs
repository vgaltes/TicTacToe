namespace TicTacToeGame.Test
{
    public static class BoardTestHelper
    {
        public static Cell[,] GetEmptyBoard()
        {
            return GetABoardWithAMarkInTheCenterOfType(Cell.Empty);
        }

        public static Cell[,] GetABoardWithAMarkInTheCenterOfType(Cell cell)
        {
            return GetABoardWithAMark(1, 1, cell);
        }

        public static Cell[,] GetABoardWithAMark(int row, int column, Cell cell)
        {
            var board = new Cell[3, 3]{{Cell.Empty, Cell.Empty, Cell.Empty},
                                                {Cell.Empty, Cell.Empty, Cell.Empty},
                                                {Cell.Empty, Cell.Empty, Cell.Empty}};

            board[row, column] = cell;

            return board;
        }
    }
}
