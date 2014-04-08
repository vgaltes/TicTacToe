using System.Collections.Generic;

namespace TicTacToeGame.Strategies
{
    public class OppositeCornerStrategy : TicTacToeStrategy
    {
        private Dictionary<MarkCoordinate, MarkCoordinate> CornersAndOpposites
            = new Dictionary<MarkCoordinate, MarkCoordinate>();

        public OppositeCornerStrategy()
        {
            CornersAndOpposites.Add(new MarkCoordinate(0, 0), new MarkCoordinate(2, 2));
            CornersAndOpposites.Add(new MarkCoordinate(0, 2), new MarkCoordinate(2, 0));
            CornersAndOpposites.Add(new MarkCoordinate(2, 0), new MarkCoordinate(0, 2));
            CornersAndOpposites.Add(new MarkCoordinate(2, 2), new MarkCoordinate(0, 0));
        }

        public bool CanHandle(Board board)
        {   
            foreach ( var cornerAndOpposite in CornersAndOpposites )
            {
                if ( IsThereAndOpponentInTheCorner(cornerAndOpposite.Key, board) 
                    && IsOppositeCornerFree(cornerAndOpposite.Value, board))
                    return true;
            }

            return false;
        }
        
        public void Update(Board board)
        {
            PutAMarkInTheOppositeSquare(board);
        }
        
        private bool IsOppositeCornerFree(MarkCoordinate markCoordinate, Board board)
        {
            return board.IsCellOfType(Cell.Empty, markCoordinate.Row, markCoordinate.Column);
        }

        private bool IsThereAndOpponentInTheCorner(MarkCoordinate markCoordinate, Board board)
        {
            return board.IsCellOfType(Cell.Opponent, markCoordinate.Row, markCoordinate.Column);
        }

        private void PutAMarkInTheOppositeSquare(Board board)
        {
            foreach (var cornerAndOpposite in CornersAndOpposites)
            {
                if (IsThereAndOpponentInTheCorner(cornerAndOpposite.Key, board)
                    && IsOppositeCornerFree(cornerAndOpposite.Value, board))
                {
                    board.FillAICell(cornerAndOpposite.Value.Row, cornerAndOpposite.Value.Column);
                    return;
                }
            }
        }
    }
}