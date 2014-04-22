using TicTacToeGame.Models;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Fakes
{
    public class AllwaysUpdateStrategy : TicTacToeStrategy
    {
        private const char AI_MARK = 'X';
        private const char OPPONENTS_MARK = 'O';
        
        public AllwaysUpdateStrategy() : base(AI_MARK, OPPONENTS_MARK) { }

        public override bool CanHandle(Board board, char mark)
        {
            return true;
        }

        public override void Update(Board board, char mark)
        {
            board.FillCell(new CellCoordinates(0, 0), mark);
        }
    }
}