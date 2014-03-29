using System;

namespace TicTacToeGame.Strategies
{
    public class BlockStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Cell[,] board)
        {
            return false;
        }

        public void Update(Cell[,] board)
        {
            throw new NotImplementedException();
        }
    }
}
