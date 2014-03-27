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
            if (IsFirstSquareFree(board))
                board[0, 0] = Cell.AI;
            else if (IsSecondSquareFree(board))
                board[0, 2] = Cell.AI;
            else if (IsThirdSquareFree(board))
                board[2, 0] = Cell.AI;
        }

        private bool IsFirstSquareFree(Cell[,] board)
        {
            return board[0, 0] == Cell.Empty;
        }

        private bool IsSecondSquareFree(Cell[,] board)
        {
            return board[0, 2] == Cell.Empty;
        }

        private bool IsThirdSquareFree(Cell[,] board)
        {
            return board[2, 0] == Cell.Empty;
        }
        private bool IsFourthSquareFree(Cell[,] board)
        {
            return board[2, 2] == Cell.Empty;
        }


        private bool ThereIsAFreeSquare(Cell[,] board)
        {
            return IsFirstSquareFree(board) ||
                IsSecondSquareFree(board) ||
                IsThirdSquareFree(board) ||
                IsFourthSquareFree(board);
        }
    }
}