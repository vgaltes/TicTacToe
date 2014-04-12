using System;
using TicTacToeGame.Models;

namespace TicTacToeGame
{
    public interface ITicTacToe
    {
        void AIMove();

        Board Board { get; }

        void OpponentMove(CellCoordinates cellCoordinate);
    }
}