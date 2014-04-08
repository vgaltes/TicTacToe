using System;

namespace TicTacToeGame.Strategies
{
    public class BlockForkStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Cell[,] board)
        {
            return true;
        }

        public void Update(Cell[,] board)
        {
            throw new NotImplementedException();
        }
    }
}