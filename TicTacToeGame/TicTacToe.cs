using System.Collections.Generic;
using TicTacToeGame.Strategies;

namespace TicTacToeGame
{
    public class TicTacToe
    {
        public virtual Cell[,] Board{get; private set;}

        private List<TicTacToeStrategy> Strategies;

        public TicTacToe()
        {
            Board = new Cell[3, 3];
            CreateStrategies();
        }

        private void CreateStrategies()
        {
            Strategies = new List<TicTacToeStrategy>
            {
                new CenterStrategy(),
                new OppositeCornerStrategy(),
                new FreeCornerStrategy()
            };
        }

        public virtual void AIMove()
        {
            foreach ( var strategy in Strategies)
            {
                if ( strategy.CanHandle(Board))
                {
                    strategy.Update(Board);
                    break;
                }
            }
        }       

        private void FillCell(int row, int column, Cell cell)
        {
            Board[row, column] = cell;
        }

        public virtual void OpponentMove(int row, int column)
        {
            FillCell(row, column, Cell.Opponent);
        }
    }
}