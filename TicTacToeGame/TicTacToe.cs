﻿using System.Collections.Generic;
using TicTacToeGame.Models;
using TicTacToeGame.Strategies;

namespace TicTacToeGame
{
    public class TicTacToe : ITicTacToe
    {
        private readonly Board board;
        
        private readonly List<TicTacToeStrategy> strategies;

        public TicTacToe(Board board, List<TicTacToeStrategy> strategies)
        {
            this.board = board;
            this.strategies = strategies;
        }

        public void OpponentMove(CellCoordinates cellCoordinate)
        {
            this.board.FillOpponentCell(cellCoordinate);
            CalculateState();
            AIMove();
        }

        public Board Board
        {
            get
            {
                return board;
            }
        }

        public TicTacToeState State
        {
            get;
            private set;
        }

        private void AIMove()
        {
            foreach (var strategy in strategies)
            {
                if (strategy.CanHandle(board))
                {
                    strategy.Update(board);
                    break;
                }
            }
        }

        private void CalculateState()
        {
            var numberOfOpponentCellsToWin = board.NumberOfColumns;
            var numberOfOpponentCells = 0;

            foreach (var line in board.Lines)
            {
                foreach (var cellCoordinate in line.Coordinates)
                {
                    if (board.IsCellOfType(CellType.Opponent, cellCoordinate))
                        numberOfOpponentCells++;
                }
            }

            if (numberOfOpponentCells == numberOfOpponentCellsToWin)
                this.State = TicTacToeState.OpponentWins;
        }
    }
}