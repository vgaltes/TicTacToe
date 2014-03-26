namespace TicTacToeGame.Strategies
{
    internal class FreeCornerStrategy
    {
        internal bool CanHandle(Cell[,] board)
        {
            return !ThereIsAFreeSquare(board);
        }

        internal void Update(Cell[,] board)
        {
            board[0, 0] = Cell.AI;
        }

        private bool ThereIsAFreeSquare(Cell[,] board)
        {
            return board[0, 0] != Cell.Empty ||
                board[0, 2] != Cell.Empty ||
                board[2, 0] != Cell.Empty ||
                board[2, 2] != Cell.Empty;
        }
    }
}