using System;

namespace TicTacToeGame.Strategies
{
    public class BlockStrategy : LineStrategy
    {
        public BlockStrategy() : base (Cell.Opponent)
        {
        }        
    }
}