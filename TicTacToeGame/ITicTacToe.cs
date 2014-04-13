using System;
using TicTacToeGame.Models;

namespace TicTacToeGame
{
    public interface ITicTacToe
    {
        void OpponentMove(CellCoordinates cellCoordinate);
    }
}