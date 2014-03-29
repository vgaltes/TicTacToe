using System.Collections.Generic;
namespace TicTacToeGame.Strategies
{
    public class MarkCoordinate
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public MarkCoordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }

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

        private bool ThereIsAnOpponentInASquare(Cell[,] board)
        {
            return board[0, 0] == Cell.Opponent ||
                board[0, 2] == Cell.Opponent ||
                board[2, 0] == Cell.Opponent ||
                board[2, 2] == Cell.Opponent;
        }

        private void PutAMarkInTheOppositeSquare(Cell[,] board)
        {
            if (board[0, 0] == Cell.Opponent)
                board[2, 2] = Cell.AI;
            if (board[0, 2] == Cell.Opponent)
                board[2, 0] = Cell.AI;
            if (board[2, 0] == Cell.Opponent)
                board[0, 2] = Cell.AI;
            if (board[2, 2] == Cell.Opponent)
                board[0, 0] = Cell.AI;
        }
    }
}