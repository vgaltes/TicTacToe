using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class FreeSideStrategy : TicTacToeStrategy
    {
        private const int INVALID_COORDINATES = -1;

        public FreeSideStrategy(char myMark, char opponentsMark) : base(myMark, opponentsMark) { }

        public override bool CanHandle(Board board, char mark)
        {
            return GetFirstEmptyCellCoordinatesInASide(board) != INVALID_COORDINATES;
        }

        public override void Update(Board board, char mark)
        {
            board.FillCell(GetFirstEmptyCellCoordinatesInASide(board), mark);
        }

        private int GetFirstEmptyCellCoordinatesInASide(Board board)
        {
            foreach ( var side in board.Sides)
            {
                if (board.IsCellOfType(' ', side))
                    return side;
            }

            return INVALID_COORDINATES;
        }
    }
}