using System;
namespace TicTacToeGame.Strategies
{
    public class ForkStrategy : LineStrategy
    {
        public ForkStrategy() : base(Cell.AI) { }
    }
}