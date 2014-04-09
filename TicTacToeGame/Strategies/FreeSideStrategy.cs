using System.Collections.Generic;
using TicTacToeGame.Models;
namespace TicTacToeGame.Strategies
{
    public class FreeSideStrategy : TicTacToeStrategy
    {

        public bool CanHandle(Board board)
        {
            foreach ( var side in board.Sides)
            {
                if ( board.IsCellOfType(Cell.Empty, side.Row, side.Column))
                    return true;
            }

            return false;
        }

        public void Update(Board board)
        {
            foreach (var side in board.Sides)
            {
                if (board.IsCellOfType(Cell.Empty, side.Row, side.Column))
                {
                    board.FillAICell(side.Row, side.Column);
                }
            }
        }
    }
}