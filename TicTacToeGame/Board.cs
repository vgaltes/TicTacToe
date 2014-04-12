﻿using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeGame.Exceptions;
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

        private CellType[,] Cells { get; set; }
        private List<Line> lines = new List<Line>();
        private Dictionary<CellCoordinates, CellCoordinates> cornersAndOpposites
            = new Dictionary<CellCoordinates, CellCoordinates>();
        private List<CellCoordinates> sides = new List<CellCoordinates>();

        public Board()
        {
            Cells = new CellType[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];

            AddRows();
            AddColumns();
            AddDiagonals();
            AddCornersAndOpposites();
            AddSides();
        }
        
        private void AddRows()
        {
            lines.Add(new Line(new CellCoordinates(0, 0), new CellCoordinates(0, 1), new CellCoordinates(0, 2)));
            lines.Add(new Line(new CellCoordinates(1, 0), new CellCoordinates(1, 1), new CellCoordinates(1, 2)));
            lines.Add(new Line(new CellCoordinates(2, 0), new CellCoordinates(2, 1), new CellCoordinates(2, 2)));
        }

        private void AddColumns()
        {
            lines.Add(new Line(new CellCoordinates(0, 0), new CellCoordinates(1, 0), new CellCoordinates(2, 0)));
            lines.Add(new Line(new CellCoordinates(0, 1), new CellCoordinates(1, 1), new CellCoordinates(2, 1)));
            lines.Add(new Line(new CellCoordinates(0, 2), new CellCoordinates(1, 2), new CellCoordinates(2, 2)));
        }
        
        private void AddDiagonals()
        {
            lines.Add(new Line(new CellCoordinates(0, 0), new CellCoordinates(1, 1), new CellCoordinates(2, 2)));
            lines.Add(new Line(new CellCoordinates(0, 2), new CellCoordinates(1, 1), new CellCoordinates(2, 0)));
        }

        private void AddCornersAndOpposites()
        {
            cornersAndOpposites.Add(new CellCoordinates(0, 0), new CellCoordinates(2, 2));
            cornersAndOpposites.Add(new CellCoordinates(0, 2), new CellCoordinates(2, 0));
            cornersAndOpposites.Add(new CellCoordinates(2, 0), new CellCoordinates(0, 2));
            cornersAndOpposites.Add(new CellCoordinates(2, 2), new CellCoordinates(0, 0));
        }

        private void AddSides()
        {
            sides.Add(new CellCoordinates(0, 1));
            sides.Add(new CellCoordinates(1, 0));
            sides.Add(new CellCoordinates(1, 2));
            sides.Add(new CellCoordinates(2, 1));
        }

        public void FillOpponentCell(CellCoordinates cellCoordinate)
        {
            if (IsCellNotEmpty(cellCoordinate))
                throw new NotAllowedMovementException();

            FillCellWithType(CellType.Opponent, cellCoordinate);
        }

        private bool IsCellNotEmpty(CellCoordinates cellCoordinate)
        {
            return Cells[cellCoordinate.Row, cellCoordinate.Column] != CellType.Empty;
        }

        public virtual void FillAICell(CellCoordinates cellCoordinate)
        {
            FillCellWithType(CellType.AI, cellCoordinate);
        }

        public void FillCellWithType(CellType cell, CellCoordinates cellCoordinate)
        {
            if ( cellCoordinate.IsValid)
                Cells[cellCoordinate.Row, cellCoordinate.Column] = cell;
        }

        public bool IsCellOfType(CellType cell, CellCoordinates cellCoordinate)
        {
            return Cells[cellCoordinate.Row, cellCoordinate.Column] == cell;
        }

        public int CountCellsOfTypeInLine(CellType cellType, Line line)
        {
            int cellCount = 0;

            foreach (var coordinate in line.Coordinates)
            {
                if (Cells[coordinate.Row, coordinate.Column] == cellType)
                    cellCount++;
            }

            return cellCount;
        }

        public IEnumerable<CellCoordinates> EmptyCells
        {
            get
            {
                for (int row = 0; row < NUMBER_OF_ROWS; row++)
                {
                    for (int column = 0; column < NUMBER_OF_COLUMNS; column++)
                    {
                        if (Cells[row, column] == CellType.Empty)
                        {
                            yield return new CellCoordinates(row, column);
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

        public Dictionary<CellCoordinates, CellCoordinates> CornersAndOpposites
        {
            get
            {
                return cornersAndOpposites;
            }
        }

        public IEnumerable<CellCoordinates> Corners
        {
            get
            {
                foreach ( var cornerAndOpposite in cornersAndOpposites)
                {
                    yield return new CellCoordinates(cornerAndOpposite.Key.Row, cornerAndOpposite.Key.Column);
                }
            }
        }

        public IEnumerable<CellCoordinates> Sides
        {
            get
            {
                return sides.AsEnumerable<CellCoordinates>();
            }
        }

        public Board GetCopyWithExtraCellOfType(CellType cell, CellCoordinates cellCoordinate)
        {
            var imaginaryBoard = new Board();
            Array.Copy(Cells, imaginaryBoard.Cells, Cells.Length);
            imaginaryBoard.FillCellWithType(cell, cellCoordinate);

            return imaginaryBoard;
        }

        public bool IsCenterEmpty()
        {
            var centerCoordinate = new CellCoordinates(CENTER_ROW, CENTER_COLUMN);
            return IsCellOfType(CellType.Empty, centerCoordinate);
        }

        public void FillCenterWithAICell()
        {
            var centerCoordinate = new CellCoordinates(CENTER_ROW, CENTER_COLUMN);
            FillAICell(centerCoordinate);
        }

        public CellType this[int row, int column]
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

        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}\n-----\n{3}|{4}|{5}\n-----\n{6}|{7}|{8}",
                Draw(Cells[0, 0]), Draw(Cells[0, 1]), Draw(Cells[0, 2]),
                Draw(Cells[1, 0]), Draw(Cells[1, 1]), Draw(Cells[1, 2]),
                Draw(Cells[2, 0]), Draw(Cells[2, 1]), Draw(Cells[2, 2]));
        }

        private string Draw(CellType cell)
        {
            if (cell == CellType.AI)
                return "X";
            if (cell == CellType.Opponent)
                return "O";
            return " ";
        }

        internal bool HasLessOpponentCellsThan(int numberOfCells)
        {
            int opponentCells = 0;

            for (int row = 0; row < NUMBER_OF_ROWS; row++)
            {
                for (int column = 0; column < NUMBER_OF_COLUMNS; column++)
                {
                    if (Cells[row, column] == CellType.Opponent)
                        opponentCells++;
                }
            }

            return opponentCells < numberOfCells;
        }
    }
}