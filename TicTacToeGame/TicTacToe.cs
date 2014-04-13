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
            if (State == TicTacToeState.Playing)
            {
                AIMove();
                CalculateState();
            }
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
            if (EvaluateWinnerIs(CellType.Opponent))
                State = TicTacToeState.OpponentWins;
            else if (EvaluateWinnerIs(CellType.AI))
                State = TicTacToeState.AIWins;
        }

        private bool EvaluateWinnerIs(CellType cellType)
        {
            var numberOfCellsToWin = board.Size;
            
            foreach (var line in board.Lines)
            {
                var numberOfCells = 0;
                foreach (var cellCoordinate in line.Coordinates)
                {
                    if (board.IsCellOfType(cellType, cellCoordinate))
                        numberOfCells++;
                }
                if (numberOfCells == numberOfCellsToWin)
                    return true;
            }

            return false;
        }
    }
}