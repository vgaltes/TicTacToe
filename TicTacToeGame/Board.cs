using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeGame.Models;
using TicTacToeGame.Strategies;

namespace TicTacToeGame
{
    public class Board
    {
        public const int NUMBER_OF_ROWS = 3;
        public const int NUMBER_OF_COLUMNS = 3;
        public const int CENTER_ROW = 1;
        public const int CENTER_COLUMN = 1;

        private Cell[,] Cells { get; set; }
        private List<Line> lines = new List<Line>();
        private Dictionary<MarkCoordinate, MarkCoordinate> cornersAndOpposites
            = new Dictionary<MarkCoordinate, MarkCoordinate>();
        private List<MarkCoordinate> sides = new List<MarkCoordinate>();

        public Board()
        {
            Cells = new Cell[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];

            AddRows();
            AddColumns();
            AddDiagonals();
            AddCornersAndOpposites();
            AddSides();
        }
        
        private void AddRows()
        {
            lines.Add(new Line(new MarkCoordinate(0, 0), new MarkCoordinate(0, 1), new MarkCoordinate(0, 2)));
            lines.Add(new Line(new MarkCoordinate(1, 0), new MarkCoordinate(1, 1), new MarkCoordinate(1, 2)));
            lines.Add(new Line(new MarkCoordinate(2, 0), new MarkCoordinate(2, 1), new MarkCoordinate(2, 2)));
        }

        private void AddColumns()
        {
            lines.Add(new Line(new MarkCoordinate(0, 0), new MarkCoordinate(1, 0), new MarkCoordinate(2, 0)));
            lines.Add(new Line(new MarkCoordinate(0, 1), new MarkCoordinate(1, 1), new MarkCoordinate(2, 1)));
            lines.Add(new Line(new MarkCoordinate(0, 2), new MarkCoordinate(1, 2), new MarkCoordinate(2, 2)));
        }
        
        private void AddDiagonals()
        {
            lines.Add(new Line(new MarkCoordinate(0, 0), new MarkCoordinate(1, 1), new MarkCoordinate(2, 2)));
            lines.Add(new Line(new MarkCoordinate(0, 2), new MarkCoordinate(1, 1), new MarkCoordinate(2, 0)));
        }

        private void AddCornersAndOpposites()
        {
            cornersAndOpposites.Add(new MarkCoordinate(0, 0), new MarkCoordinate(2, 2));
            cornersAndOpposites.Add(new MarkCoordinate(0, 2), new MarkCoordinate(2, 0));
            cornersAndOpposites.Add(new MarkCoordinate(2, 0), new MarkCoordinate(0, 2));
            cornersAndOpposites.Add(new MarkCoordinate(2, 2), new MarkCoordinate(0, 0));
        }

        private void AddSides()
        {
            sides.Add(new MarkCoordinate(0, 1));
            sides.Add(new MarkCoordinate(1, 0));
            sides.Add(new MarkCoordinate(1, 2));
            sides.Add(new MarkCoordinate(2, 1));
        }

        public void FillOpponentCell(int row, int column)
        {
            FillCellWithType(Cell.Opponent, row, column);
        }

        public void FillAICell(int row, int column)
        {
            FillCellWithType(Cell.AI, row, column);
        }

        public void FillCellWithType(Cell cell, int row, int column)
        {
            Cells[row, column] = cell;
        }

        public bool IsCellOfType(Cell cell, int row, int column)
        {
            return Cells[row, column] == cell;
        }

        public int CountCellsOfTypeInLine(Cell cellType, Line line)
        {
            int cellCount = 0;

            foreach (var coordinate in line.Coordinates)
            {
                if (Cells[coordinate.Row, coordinate.Column] == cellType)
                    cellCount++;
            }

            return cellCount;
        }

        public IEnumerable<MarkCoordinate> EmptyCells
        {
            get
            {
                for (int row = 0; row < NUMBER_OF_ROWS; row++)
                {
                    for (int column = 0; column < NUMBER_OF_COLUMNS; column++)
                    {
                        if (Cells[row, column] == Cell.Empty)
                        {
                            yield return new MarkCoordinate(row, column);
                        }
                    }
                }
            }
        }

        public IEnumerable<Line> Lines
        {
            get
            {
                return lines.AsEnumerable<Line>();
            }
        }

        public Dictionary<MarkCoordinate, MarkCoordinate> CornersAndOpposites
        {
            get
            {
                return cornersAndOpposites;
            }
        }

        public IEnumerable<MarkCoordinate> Corners
        {
            get
            {
                foreach ( var cornerAndOpposite in cornersAndOpposites)
                {
                    yield return new MarkCoordinate(cornerAndOpposite.Key.Row, cornerAndOpposite.Key.Column);
                }
            }
        }

        public IEnumerable<MarkCoordinate> Sides
        {
            get
            {
                return sides.AsEnumerable<MarkCoordinate>();
            }
        }

        public Board GetCopyWithExtraCellOfType(Cell cell, int row, int column)
        {
            var imaginaryBoard = new Board();
            Array.Copy(Cells, imaginaryBoard.Cells, Cells.Length);
            imaginaryBoard.FillCellWithType(cell, row, column);

            return imaginaryBoard;
        }

        public bool IsCenterEmpty()
        {
            return IsCellOfType(Cell.Empty, CENTER_ROW, CENTER_COLUMN);
        }

        public void FillCenterWithAICell()
        {
            FillAICell(CENTER_ROW, CENTER_COLUMN);
        }

        public Cell this[int row, int column]
        {
            get
            {
                return Cells[row, column];
            }
        }

        public override bool Equals(object obj)
        {
            Board boardToCompare = obj as Board;
            if ( boardToCompare == null)
                return false;

            for (int row = 0; row < NUMBER_OF_ROWS; row++)
            {
                for (int column = 0; column < NUMBER_OF_COLUMNS; column++)
                {
                    if (Cells[row, column] != boardToCompare[row, column])
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            int multiplier = 1;

            for (int row = 0; row < NUMBER_OF_ROWS; row++)
            {
                for (int column = 0; column < NUMBER_OF_COLUMNS; column++)
                {
                    hashCode += multiplier * (int) Cells[row, column];
                    multiplier += 10;
                }
            }

            return hashCode;
        }
    }
}