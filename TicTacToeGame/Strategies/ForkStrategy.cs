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
            foreach (var emptyCell in board.EmptyCells)
            {
                int suitableLines = 0;

                var imaginaryBoard = board.GetCopyWithExtraCellOfType(Cell.AI, emptyCell);

                foreach (var line in board.Lines)
                {
                    if (IsLineSuitableForAFork(imaginaryBoard, line))
                        suitableLines++;
                }

                if (suitableLines >= 2)
                    return true;
            }

            return false;
        }

        public void Update(Board board)
        {
            
            foreach (var emptyCell in board.EmptyCells)
            {
                int suitableLines = 0;

                var imaginaryBoard = board.GetCopyWithExtraCellOfType(Cell.AI, emptyCell);

                foreach ( var line in board.Lines)
                { 
                    if (IsLineSuitableForAFork(imaginaryBoard, line))
                            suitableLines++;
                }

                if (suitableLines >= 2)
                {
                    board.FillAICell(emptyCell);
                    return;
                }
            }            
        }

        private bool IsLineSuitableForAFork(Board board, Line line)
        {
            int aiCells = 0;

            foreach(var coordinate in line.Coordinates )
            {
                if(board.IsCellOfType(Cell.Opponent, coordinate))
                    return false;

                if (board.IsCellOfType(Cell.AI, coordinate))
                    aiCells++;
            }

            return aiCells == 2;
        }
    }
}