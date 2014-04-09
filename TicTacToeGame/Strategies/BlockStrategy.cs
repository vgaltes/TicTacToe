using System;

namespace TicTacToeGame.Strategies
{
    public class BlockStrategy : EvaluatedLineStrategy
    {
        public BlockStrategy() : base (Cell.Opponent)
        {
        }        
    }
}