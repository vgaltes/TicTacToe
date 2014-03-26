namespace TicTacToeGame.Strategies
{
    public class FreeCornerStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Cell[,] board)
        {
            return ThereIsAFreeSquare(board);
        }

        public void Update(Cell[,] board)
        {
            if (FirstSquareIsFree(board))
                board[0, 0] = Cell.AI;
            else if (SecondSquareIsFree(board))
                board[0, 2] = Cell.AI;
        }

        private bool FirstSquareIsFree(Cell[,] board)
        {
            return board[0, 0] == Cell.Empty;
        }

        private bool SecondSquareIsFree(Cell[,] board)
        {
            return board[0, 2] == Cell.Empty;
        }

        private bool ThereIsAFreeSquare(Cell[,] board)
        {
            return board[0, 0] == Cell.Empty ||
                board[0, 2] == Cell.Empty ||
                board[2, 0] == Cell.Empty;
        }
    }
}