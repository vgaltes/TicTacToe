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

        public bool CanHandle(Cell[,] board)
        {
            foreach (var corner in Corners)
            {
                if (board[corner.Row, corner.Column] == Cell.Empty)
                    return true;
            }

            return false;
        }

        public void Update(Cell[,] board)
        {
            foreach (var corner in Corners)
            {
                if (board[corner.Row, corner.Column] == Cell.Empty)
                {
                    board[corner.Row, corner.Column] = Cell.AI;
                    return;
                }
            }
        }
    }
}