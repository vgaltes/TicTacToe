using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Strategies
{
    public class CenterStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Board board)
        {
            return board.IsCenterEmpty();
        }

        public void Update(Board board)
        {
            board.FillCenterWithAICell();
        }
    }
}