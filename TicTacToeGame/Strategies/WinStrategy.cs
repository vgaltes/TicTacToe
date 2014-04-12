using TicTacToeGame.Models;
namespace TicTacToeGame.Strategies
{
    public class WinStrategy : EvaluateLineStrategy
    {
        public WinStrategy() : base(CellType.AI) { }
    }
}