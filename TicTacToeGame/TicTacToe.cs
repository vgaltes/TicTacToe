using System.Collections.Generic;
using TicTacToeGame.Strategies;

namespace TicTacToeGame
{
    public class TicTacToe
    {
        public virtual Board Board { get; private set; }
        
        private List<TicTacToeStrategy> Strategies;

        public TicTacToe()
        {
            Board = new Board();
            CreateStrategies();
        }

        private void CreateStrategies()
        {
            Strategies = new List<TicTacToeStrategy>
            {
                new WinStrategy(),
                new BlockStrategy(),
                new ForkStrategy(),
                new BlockForkStrategy(),
                new CenterStrategy(),
                new OppositeCornerStrategy(),
                new FreeCornerStrategy(),
                new FreeSideStrategy()
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

        public virtual void OpponentMove(int row, int column)
        {
            this.Board.FillOpponentCell(row, column);
        }
    }
}