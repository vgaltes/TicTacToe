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

        public void AIMove()
        {
            foreach ( var strategy in strategies)
            {
                if (strategy.CanHandle(board))
                {
                    strategy.Update(board);
                    break;
                }
            }
        }       

        public void OpponentMove(CellCoordinates cellCoordinate)
        {
            this.board.FillOpponentCell(cellCoordinate);
        }
    }
}