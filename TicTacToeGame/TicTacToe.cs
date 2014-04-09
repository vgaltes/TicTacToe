using System.Collections.Generic;
using TicTacToeGame.Models;
using TicTacToeGame.Strategies;

namespace TicTacToeGame
{
    public class TicTacToe : ITicTacToe
    {
        public Board Board { get; private set; }
        
        private List<TicTacToeStrategy> strategies;

        public TicTacToe(List<TicTacToeStrategy> strategies)
        {
            Board = new Board();
            this.strategies = strategies;
        }

        public void AIMove()
        {
            foreach ( var strategy in strategies)
            {
                if ( strategy.CanHandle(Board))
                {
                    strategy.Update(Board);
                    break;
                }
            }
        }       

        public void OpponentMove(MarkCoordinate cellCoordinate)
        {
            this.Board.FillOpponentCell(cellCoordinate);
        }
    }
}