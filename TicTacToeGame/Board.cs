using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeGame.Exceptions;
using TicTacToeGame.Models;

namespace TicTacToeGame
{
    public class Board
    {
        public const int SIZE = 3;
        public const int CENTER_ROW = 1;
        public const int CENTER_COLUMN = 1;
        public const char EMPTY_CELL = ' ';

        private char[] Cells { get; set; }

        private List<int[]> lines = new List<int[]>();
        private List<int[]> cornersAndOpposites = new List<int[]>();
        private List<int> sides = new List<int>();

        public virtual TicTacToeBoardState State { get; set; }
        public virtual char Winner{get;set;}

        public Board()
        {
            Cells = new char[SIZE * SIZE];
            for (int i = 0; i < SIZE * SIZE; i++)
                Cells[i] = EMPTY_CELL;

            AddLines();
            AddCornersAndOpposites();
            AddSides();

            State = TicTacToeBoardState.Playing;
            Winner = EMPTY_CELL;
        }

        private void AddLines()
        {
            lines.Add(new int[3] { 0, 1, 2 });
            lines.Add(new int[3] { 3, 4, 5 });
            lines.Add(new int[3] { 6, 7, 8 });

            lines.Add(new int[3] { 0, 3, 6 });
            lines.Add(new int[3] { 1, 4, 7 });
            lines.Add(new int[3] { 2, 5, 8 });

            lines.Add(new int[3] { 0, 4, 8 });
            lines.Add(new int[3] { 2, 4, 6 });
        }

        private void AddCornersAndOpposites()
        {
            cornersAndOpposites.Add(new int[2] { 0, 8 });
            cornersAndOpposites.Add(new int[2] { 2, 6 });
            cornersAndOpposites.Add(new int[2] { 6, 2 });
            cornersAndOpposites.Add(new int[2] { 8, 0 });
        }

        private void AddSides()
        {
            sides.AddRange(new int[4] { 1, 3, 5, 7 });
        }

        public virtual void FillCell(CellCoordinates cellCoordinate, char mark)
        {
            if (State != TicTacToeBoardState.Playing ||
                AreCoordinatesOutsideTheBoard(cellCoordinate) || IsCellNotEmpty(cellCoordinate))
                throw new NotAllowedMovementException();

            Cells[cellCoordinate.Row * SIZE + cellCoordinate.Column] = mark;
            CheckForWinner();
        }

        public virtual void FillCell(int cellCoordinate, char mark)
        {
            if (State != TicTacToeBoardState.Playing ||
                AreCoordinatesOutsideTheBoard(cellCoordinate) || IsCellNotEmpty(cellCoordinate))
                throw new NotAllowedMovementException();

            Cells[cellCoordinate] = mark;
            CheckForWinner();
        }

        private void CheckForWinner()
        {
            var numberOfCellsToWin = Size;
            
            foreach (var line in lines)
            {
                var numberOfCells = 1;
                var cellType = Cells[line[0]];
                if ( cellType != EMPTY_CELL)
                {
                    for ( int i = 1; i < SIZE; i++)
                    {
                        if (IsCellOfType(cellType, line[i]))
                            numberOfCells++;
                    }

                    if (numberOfCells == numberOfCellsToWin)
                    {
                        State = TicTacToeBoardState.SomeoneWins;
                        Winner = cellType;
                        break;
                    }
                }
            }                
        }

        public bool IsCellEmpty(CellCoordinates cellCoordinate)
        {
            return Cells[cellCoordinate.Row * SIZE + cellCoordinate.Column] == EMPTY_CELL;
        }

        public bool IsCellEmpty(int cellCoordinate)
        {
            return Cells[cellCoordinate] == EMPTY_CELL;
        }

        private bool IsCellNotEmpty(CellCoordinates cellCoordinate)
        {
            return !IsCellEmpty(cellCoordinate);
        }

        private bool IsCellNotEmpty(int cellCoordinate)
        {
            return !IsCellEmpty(cellCoordinate);
        }

        private bool AreCoordinatesOutsideTheBoard(CellCoordinates cellCoordinate)
        {
            return (cellCoordinate.Row >= SIZE || cellCoordinate.Column >= SIZE);
        }

        private bool AreCoordinatesOutsideTheBoard(int cellCoordinate)
        {
            return (cellCoordinate >= SIZE * SIZE);
        }

        public bool IsCellOfType(char mark, CellCoordinates cellCoordinate)
        {
            return Cells[cellCoordinate.Row * SIZE + cellCoordinate.Column] == mark;
        }

        public bool IsCellOfType(char mark, int cellCoordinate)
        {
            return Cells[cellCoordinate] == mark;
        }

        public int CountCellsOfTypeInLine(char mark, int[] line)
        {
            int cellCount = 0;

            foreach (var coordinate in line)
            {
                if (Cells[coordinate] == mark)
                    cellCount++;
            }

            return cellCount;
        }

        public IEnumerable<int> EmptyCells
        {
            get
            {
                for ( int i = 0; i < SIZE * SIZE; i++)
                {
                    if (IsCellEmpty(i))
                        yield return i;
                }
            }
        }

        public IEnumerable<int[]> Lines
        {
            get
            {
                return lines;
            }
        }

        public List<int[]> CornersAndOpposites
        {
            get
            {
                return cornersAndOpposites;
            }
        }

        public IEnumerable<int> Corners
        {
            get
            {
                foreach (var cornerAndOpposite in cornersAndOpposites)
                {
                    yield return cornerAndOpposite[0];
                }
            }
        }

        public IEnumerable<int> Sides
        {
            get
            {
                return sides.AsEnumerable();
            }
        }

        public Board GetCopyWithExtraCellOfType(char mark, int cellCoordinate)
        {
            var imaginaryBoard = new Board();
            Array.Copy(Cells, imaginaryBoard.Cells, Cells.Length);
            imaginaryBoard.FillCell(cellCoordinate, mark);

            return imaginaryBoard;
        }

        public bool IsCenterEmpty()
        {
            var centerCoordinate = new CellCoordinates(CENTER_ROW, CENTER_COLUMN);
            return IsCellOfType(' ', centerCoordinate);
        }

        public void FillCenterWithCell(char mark)
        {
            var centerCoordinate = new CellCoordinates(CENTER_ROW, CENTER_COLUMN);
            FillCell(centerCoordinate, mark);
        }

        public char this[int index]
        {
            get
            {
                return Cells[index];
            }
        }

        public override bool Equals(object obj)
        {
            Board boardToCompare = obj as Board;
            if (boardToCompare == null)
                return false;

            for (int i = 0; i < SIZE * SIZE; i++)
                if (Cells[i] != boardToCompare[i])
                        return false;

            return true;
        }
        
        internal bool HasLessCellsOfTypeThan(char mark, int numberOfCells)
        {
            int opponentCells = 0;

            for (int i = 0; i < SIZE * SIZE; i++)
                if ( Cells[i] == mark)
                    opponentCells++;

            return opponentCells < numberOfCells;
        }

        public int Size
        {
            get
            {
                return SIZE;
            }
        }

        public virtual void Reset()
        {
            for (int i = 0; i < SIZE * SIZE; i++)
                Cells[i] = EMPTY_CELL;

            State = TicTacToeBoardState.Playing;
            Winner = EMPTY_CELL;
        }
    }
}