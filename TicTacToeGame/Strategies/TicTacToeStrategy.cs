using System;
namespace TicTacToeGame.Strategies
{
    interface TicTacToeStrategy
    {
        bool CanHandle(TicTacToeGame.Cell[,] board);
        void Update(TicTacToeGame.Cell[,] board);
    }
}
