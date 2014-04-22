using TicTacToeGame.Models;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Fakes
{
    public class FillFirstRowStrategy : TicTacToeStrategy
    {
        public const int FIRST_ROW = 0;
        private const char AI_MARK = 'X';
        private const char OPPONENTS_MARK = 'O';

        public FillFirstRowStrategy() : base(AI_MARK, OPPONENTS_MARK) { }

        public override bool CanHandle(Board board, char mark)
        {
            return true;
        }

        public override void Update(Board board, char mark)
        {
            for (var column = 0; column < board.Size; column++)
            {
                if (board.IsCellOfType(' ', new CellCoordinates(FIRST_ROW, column)))
                {
                    board.FillCell(new CellCoordinates(FIRST_ROW, column), mark);
                    break;
                }
            }   
        }
    }
}