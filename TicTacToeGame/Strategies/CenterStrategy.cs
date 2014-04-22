using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Strategies
{
    public class CenterStrategy : TicTacToeStrategy
    {
        public CenterStrategy(char myMark, char opponentsMark) : base(myMark, opponentsMark) { }

        public override bool CanHandle(Board board, char mark)
        {
            return board.IsCenterEmpty();
        }

        public override void Update(Board board, char mark)
        {
            board.FillCenterWithCell(mark);
        }
    }
}