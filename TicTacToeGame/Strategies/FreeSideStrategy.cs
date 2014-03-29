using System.Collections.Generic;
namespace TicTacToeGame.Strategies
{
    public class FreeSideStrategy
    {
        private List<MarkCoordinate> Sides
            = new List<MarkCoordinate>();

        public FreeSideStrategy()
        {
            Sides.Add(new MarkCoordinate(0, 1));
        }

        public bool CanHandle(Cell[,] board)
        {
            return board[Sides[0].Row, Sides[0].Column] == Cell.Empty;
        }
    }
}