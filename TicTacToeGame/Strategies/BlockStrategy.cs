using System;
using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class BlockStrategy : EvaluateLineStrategy
    {
        public BlockStrategy() : base (CellType.Opponent)
        {
        }        
    }
}