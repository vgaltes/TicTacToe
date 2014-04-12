using System;
using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class BlockStrategy : EvaluatedLineStrategy
    {
        public BlockStrategy() : base (CellType.Opponent)
        {
        }        
    }
}