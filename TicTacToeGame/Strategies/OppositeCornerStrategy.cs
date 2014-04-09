using System.Collections.Generic;
using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
    public class OppositeCornerStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Board board)
        {   
            foreach ( var cornerAndOpposite in board.CornersAndOpposites )
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
            return board.IsCellOfType(Cell.Empty, markCoordinate);
        }

        private bool IsThereAndOpponentInTheCorner(MarkCoordinate markCoordinate, Board board)
        {
            return board.IsCellOfType(Cell.Opponent, markCoordinate);
        }

        private void PutAMarkInTheOppositeSquare(Board board)
        {
            foreach (var cornerAndOpposite in board.CornersAndOpposites)
            {
                if (IsThereAndOpponentInTheCorner(cornerAndOpposite.Key, board)
                    && IsOppositeCornerFree(cornerAndOpposite.Value, board))
                {
                    board.FillAICell(cornerAndOpposite.Value);
                    return;
                }
            }
        }
    }
}