using System.Collections.Generic;

namespace TicTacToeGame.Strategies
{
    public class FreeCornerStrategy : TicTacToeStrategy
    {
        private List<MarkCoordinate> Corners
            = new List<MarkCoordinate>();

        public FreeCornerStrategy()
        {
            Corners.Add(new MarkCoordinate(0, 0));
            Corners.Add(new MarkCoordinate(0, 2));
            Corners.Add(new MarkCoordinate(2, 0));
            Corners.Add(new MarkCoordinate(2, 2));
        }

        public bool CanHandle(Board board)
        {
            foreach (var corner in Corners)
            {
                if ( board.IsCellOfType(Cell.Empty, corner.Row, corner.Column))
                    return true;
            }

            return false;
        }

        public void Update(Board board)
        {
            foreach (var corner in Corners)
            {
                if (board.IsCellOfType(Cell.Empty, corner.Row, corner.Column))
                {
                    board.FillAICell(corner.Row, corner.Column);
                    return;
                }
            }
        }
    }
}