using System;
using TicTacToeGame.Models;

namespace TicTacToeGame
{
    public interface ITicTacToe
    {
        void AIMove();

        void OpponentMove(CellCoordinates cellCoordinate);
    }
}