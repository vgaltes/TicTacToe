using System;
namespace TicTacToeGame.Strategies
{
    public class ForkStrategy : LineStrategy
    {
        public ForkStrategy() : base(Cell.AI) { }

        public new bool CanHandle(Cell[,] board)
        {
            int suitableLines = 0;

            for ( int row = 0; row < 3; row++ )
            {
                for ( int column = 0; column < 3; column++)
                {
                    if ( board[row, column] == Cell.Empty)
                    {
                        foreach ( var line in Lines)
                        {
                            if (line.LineStart.Row == row && line.LineStart.Column == column ||
                                line.LineEnd.Row == row && line.LineEnd.Column == column ||
                                line.Evaluate.Row == row && line.Evaluate.Column == column)
                            {
                                if ( IsLineSuitableForAFork(board, line))
                                    suitableLines++;
                            }   
                        }
                    }
                }
            }

            return suitableLines >= 2;
        }

        private bool IsLineSuitableForAFork(Cell[,] board, Line line)
        {
            int aiCells = 0;

            if (board[line.LineStart.Row, line.LineStart.Column] == Cell.Opponent ||
                board[line.LineEnd.Row, line.LineEnd.Column] == Cell.Opponent ||
                board[line.Evaluate.Row, line.Evaluate.Column] == Cell.Opponent)
                return false;
            
            if (board[line.LineStart.Row, line.LineStart.Column] == Cell.AI)
                aiCells++;
            if (board[line.LineEnd.Row, line.LineEnd.Column] == Cell.AI)
                aiCells++;
            if (board[line.Evaluate.Row, line.Evaluate.Column] == Cell.AI)
                aiCells++;

            return aiCells == 1;
        }
    }
}