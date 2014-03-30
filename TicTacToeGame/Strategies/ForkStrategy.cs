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
                                suitableLines++;
                        }
                    }
                }
            }

            return suitableLines >= 2;
        }
    }
}