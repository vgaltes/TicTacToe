using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class OppositeCornerStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Board board)
        {
            return GetFirstEmptyCellCoordinatesInAnOppositeCorner(board).IsValid;
        }
        
        public void Update(Board board)
        {
            board.FillAICell(GetFirstEmptyCellCoordinatesInAnOppositeCorner(board));
        }

        private CellCoordinates GetFirstEmptyCellCoordinatesInAnOppositeCorner(Board board)
        {
            foreach (var cornerAndOpposite in board.CornersAndOpposites)
            {
                if (IsThereAndOpponentInTheCorner(cornerAndOpposite.Key, board)
                    && IsOppositeCornerFree(cornerAndOpposite.Value, board))
                    return cornerAndOpposite.Value;
            }

            return CellCoordinates.InvalidCoordinates;
        }
        
        private bool IsOppositeCornerFree(CellCoordinates markCoordinate, Board board)
        {
            return board.IsCellOfType(CellType.Empty, markCoordinate);
        }

        private bool IsThereAndOpponentInTheCorner(CellCoordinates markCoordinate, Board board)
        {
            return board.IsCellOfType(CellType.Opponent, markCoordinate);
        }
    }
}