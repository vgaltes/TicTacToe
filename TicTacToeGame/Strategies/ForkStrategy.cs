﻿using System;
using System.Collections;
using System.Collections.Generic;
using TicTacToeGame.Models;
namespace TicTacToeGame.Strategies
{
    public class ForkStrategy : TicTacToeStrategy
    {
        public bool CanHandle(Board board)
        {
            return GetCellCoordinatesSuitableForFork(board).IsValid;
        }

        public void Update(Board board)
        {
            board.FillAICell(GetCellCoordinatesSuitableForFork(board));
        }

        private CellCoordinates GetCellCoordinatesSuitableForFork(Board board)
        {
            foreach (var emptyCell in board.EmptyCells)
            {
                int suitableLines = 0;

                var imaginaryBoard = board.GetCopyWithExtraCellOfType(CellType.AI, emptyCell);

                foreach (var line in board.Lines)
                {
                    if (IsLineSuitableForAFork(imaginaryBoard, line))
                        suitableLines++;
                }

                if (suitableLines >= 2)
                    return emptyCell;
            }

            return CellCoordinates.InvalidCoordinates;
        }

        private bool IsLineSuitableForAFork(Board board, Line line)
        {
            int aiCells = 0;

            foreach(var coordinate in line.Coordinates )
            {
                if(board.IsCellOfType(CellType.Opponent, coordinate))
                    return false;

                if (board.IsCellOfType(CellType.AI, coordinate))
                    aiCells++;
            }

            return aiCells == 2;
        }
    }
}