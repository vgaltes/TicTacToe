namespace TicTacToeGame.Strategies
{
    public class OppositeCornerStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Cell[,] board)
        {
            return ThereIsAnOpponentInASquare(board);
        }

        public void Update(Cell[,] board)
        {
            PutAMarkInTheOppositeSquare(board);
        }

        private bool ThereIsAnOpponentInASquare(Cell[,] board)
        {
            return board[0, 0] == Cell.Opponent ||
                board[0, 2] == Cell.Opponent ||
                board[2, 0] == Cell.Opponent ||
                board[2, 2] == Cell.Opponent;
        }

        private void PutAMarkInTheOppositeSquare(Cell[,] board)
        {
            if (board[0, 0] == Cell.Opponent)
                board[2, 2] = Cell.AI;
            if (board[0, 2] == Cell.Opponent)
                board[2, 0] = Cell.AI;
            if (board[2, 0] == Cell.Opponent)
                board[0, 2] = Cell.AI;
            if (board[2, 2] == Cell.Opponent)
                board[0, 0] = Cell.AI;
        }
    }
}