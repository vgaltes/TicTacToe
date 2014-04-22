using System;
using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class BlockStrategy : EvaluateLineStrategy
    {
        public BlockStrategy(char myMark, char opponentsMark) : base (opponentsMark)
        {
        }        
    }
}