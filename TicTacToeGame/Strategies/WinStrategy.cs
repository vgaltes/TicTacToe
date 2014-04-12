using TicTacToeGame.Models;
namespace TicTacToeGame.Strategies
{
    public class WinStrategy : EvaluatedLineStrategy
    {
        public WinStrategy() : base(CellType.AI) { }
    }
}