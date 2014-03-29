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

        public bool CanHandle(Cell[,] board)
        {   
            foreach ( var cornerAndOpposite in CornersAndOpposites )
            {
                if ( IsThereAndOpponentInTheCorner(cornerAndOpposite.Key, board) 
                    && IsOppositeCornerFree(cornerAndOpposite.Value, board))
                    return true;
            }

            return false;
        }
        
        public void Update(Cell[,] board)
        {
            PutAMarkInTheOppositeSquare(board);
        }
        
        private bool IsOppositeCornerFree(MarkCoordinate markCoordinate, Cell[,] board)
        {
            return board[markCoordinate.Row, markCoordinate.Column] == Cell.Empty;
        }

        private bool IsThereAndOpponentInTheCorner(MarkCoordinate markCoordinate, Cell[,] board)
        {
            return board[markCoordinate.Row, markCoordinate.Column] == Cell.Opponent;
        }

        private void PutAMarkInTheOppositeSquare(Cell[,] board)
        {
            foreach (var cornerAndOpposite in CornersAndOpposites)
            {
                if (IsThereAndOpponentInTheCorner(cornerAndOpposite.Key, board)
                    && IsOppositeCornerFree(cornerAndOpposite.Value, board))
                {
                    board[cornerAndOpposite.Value.Row, cornerAndOpposite.Value.Column] = Cell.AI;
                }
            }
        }
    }
}