using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class WinStrategy : EvaluateLineStrategy
    {
        public WinStrategy(char myMark, char opponentsMark) : base(myMark) { }
    }
}