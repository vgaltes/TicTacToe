using TicTacToeGame.Strategies;

namespace TicTacToeGame
{
    public class TicTacToe
    {
        public Cell[,] Board{get; private set;}

        public TicTacToe()
        {
            Board = new Cell[3, 3];
        }

        public void AIMove()
        {
            var centerStrategy = new CenterStrategy();
            var oppositeCornerStrategy = new OppositeCornerStrategy();
            var freeCornerStrategy = new FreeCornerStrategy();

            if (centerStrategy.CanHandle(Board))
                centerStrategy.Update(Board);
            else if (oppositeCornerStrategy.CanHandle(Board))
                oppositeCornerStrategy.Update(Board);
            else if (freeCornerStrategy.CanHandle(Board))
                freeCornerStrategy.Update(Board);
        }       

        private void FillCell(int row, int column, Cell cell)
        {
            Board[row, column] = cell;
        }

        public void OpponentMove(int row, int column)
        {
            FillCell(row, column, Cell.Opponent);
        }
    }
}