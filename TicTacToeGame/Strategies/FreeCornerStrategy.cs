using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class FreeCornerStrategy : TicTacToeStrategy
    {
        private const int INVALID_COORDINATES = -1;

        public FreeCornerStrategy(char myMark, char opponentsMark) : base(myMark, opponentsMark) { }

        public override bool CanHandle(Board board, char mark)
        {
            return GetFirstEmptyCellCoordinatesInACorner(board) != INVALID_COORDINATES;
        }

        public override void Update(Board board, char mark)
        {
            board.FillCell(GetFirstEmptyCellCoordinatesInACorner(board), mark);
        }

        private int GetFirstEmptyCellCoordinatesInACorner(Board board)
        {
            foreach (var corner in board.Corners)
            {
                if (board.IsCellOfType(' ', corner))
                    return corner;
            }

            return INVALID_COORDINATES;
        }
    }
}