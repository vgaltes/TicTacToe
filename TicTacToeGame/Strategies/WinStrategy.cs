namespace TicTacToeGame.Strategies
{
    public class WinStrategy : EvaluatedLineStrategy
    {
        public WinStrategy() : base(Cell.AI) { }
    }
}