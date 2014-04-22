using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class OppositeCornerStrategy : TicTacToeStrategy
    {
        private const int INVALID_COORDINATES = -1;
        public OppositeCornerStrategy(char myMark, char opponentsMark) : base(myMark, opponentsMark) { }

        public override bool CanHandle(Board board, char mark)
        {
            return GetFirstEmptyCellCoordinatesInAnOppositeCorner(board) != INVALID_COORDINATES;
        }

        public override void Update(Board board, char mark)
        {
            board.FillCell(GetFirstEmptyCellCoordinatesInAnOppositeCorner(board), mark);
        }

        private int GetFirstEmptyCellCoordinatesInAnOppositeCorner(Board board)
        {
            foreach (var cornerAndOpposite in board.CornersAndOpposites)
            {
                if (IsThereAndOpponentInTheCorner(cornerAndOpposite[0], board)
                    && IsOppositeCornerFree(cornerAndOpposite[1], board))
                    return cornerAndOpposite[1];
            }

            return INVALID_COORDINATES;
        }
        
        private bool IsOppositeCornerFree(int markCoordinate, Board board)
        {
            return board.IsCellOfType(' ', markCoordinate);
        }

        private bool IsThereAndOpponentInTheCorner(int markCoordinate, Board board)
        {
            return board.IsCellOfType(opponentsMark, markCoordinate);
        }
    }
}