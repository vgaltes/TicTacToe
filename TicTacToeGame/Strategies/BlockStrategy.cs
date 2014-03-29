using System;

namespace TicTacToeGame.Strategies
{
    public class BlockStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Cell[,] board)
        {
            if (board[0, 0] == Cell.Opponent && board[0, 1] == Cell.Opponent)
                return true;

            return false;
        }

        public void Update(Cell[,] board)
        {
            throw new NotImplementedException();
        }
    }
}
