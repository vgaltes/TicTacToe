using System.Collections.Generic;
namespace TicTacToeGame.Strategies
{
    public class FreeSideStrategy : TicTacToeStrategy
    {
        private List<MarkCoordinate> Sides
            = new List<MarkCoordinate>();

        public FreeSideStrategy()
        {
            Sides.Add(new MarkCoordinate(0, 1));
            Sides.Add(new MarkCoordinate(1, 0));
            Sides.Add(new MarkCoordinate(1, 2));
            Sides.Add(new MarkCoordinate(2, 1));
        }

        public bool CanHandle(Board board)
        {
            foreach ( var side in Sides)
            {
                if ( board.IsCellOfType(Cell.Empty, side.Row, side.Column))
                    return true;
            }

            return false;
        }


        public void Update(Board board)
        {
            foreach (var side in Sides)
            {
                if (board.IsCellOfType(Cell.Empty, side.Row, side.Column))
                {
                    board.FillAICell(side.Row, side.Column);
                }
            }
        }
    }
}