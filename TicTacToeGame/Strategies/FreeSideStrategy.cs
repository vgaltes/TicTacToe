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
            Sides.Add(new MarkCoordinate(1, 0));
            Sides.Add(new MarkCoordinate(1, 2));
        }

        public bool CanHandle(Cell[,] board)
        {
            foreach ( var side in Sides)
            {
                if (board[side.Row, side.Column] == Cell.Empty)
                    return true;
            }

            return false;
        }
    }
}