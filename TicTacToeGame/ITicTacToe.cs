using System;
using TicTacToeGame.Models;

namespace TicTacToeGame
{
    public interface ITicTacToe
    {  
        TicTacToeState State { get; }

        Board Board { get; }

        void HumanMove(CellCoordinates cellCoordinate);

        void AIMove();

        void Reset();
    }
}