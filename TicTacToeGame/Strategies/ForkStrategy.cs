using System;
using System.Collections;
using System.Collections.Generic;
namespace TicTacToeGame.Strategies
{
    public class ForkStrategy : LineStrategy
    {
        public ForkStrategy() : base(Cell.AI) { }

        public override bool CanHandle(Board board)
        {
            foreach (var emptyCell in board.EmptyCells)
            {
                int suitableLines = 0;

                var imaginaryBoard = board.GetCopyWithExtraCellOfType(Cell.AI, emptyCell.Row, emptyCell.Column);

                foreach (var line in Lines)
                {
                    if (IsLineSuitableForAFork(imaginaryBoard, line))
                        suitableLines++;
                }

                if (suitableLines >= 2)
                    return true;
            }

            return false;
        }

        public override void Update(Board board)
        {
            
            foreach (var emptyCell in board.EmptyCells)
            {
                int suitableLines = 0;

                var imaginaryBoard = board.GetCopyWithExtraCellOfType(Cell.AI, emptyCell.Row, emptyCell.Column);

                foreach ( var line in Lines)
                { 
                    if (IsLineSuitableForAFork(imaginaryBoard, line))
                            suitableLines++;
                }

                if (suitableLines >= 2)
                {
                    board.FillAICell(emptyCell.Row, emptyCell.Column);
                    return;
                }
            }            
        }

        private IEnumerable<Line> LinesWhichCrossesTheCell(MarkCoordinate cell)
        {
            foreach (var line in Lines)
            {
                foreach ( var coordinate in line.Coordinates )
                {
                    if (coordinate.Row == cell.Row && coordinate.Column == cell.Column)
                        yield return line;
                }
            }
        }

        private bool IsLineSuitableForAFork(Board board, Line line)
        {
            int aiCells = 0;

            foreach(var coordinate in line.Coordinates )
            {
                if(board.IsCellOfType(Cell.Opponent, coordinate.Row, coordinate.Column))
                    return false;

                if (board.IsCellOfType(Cell.AI, coordinate.Row, coordinate.Column))
                    aiCells++;
            }

            return aiCells == 2;
        }
    }
}