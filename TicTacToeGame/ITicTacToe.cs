using System;
using TicTacToeGame.Models;

namespace TicTacToeGame
{
    public interface ITicTacToe
    {  
        TicTacToeState State { get; }

        Board Board { get; }

        void OpponentMove(CellCoordinates cellCoordinate);

        void Reset();

        void SetInitialPlayer(CellType initialPlayer);
    }
}