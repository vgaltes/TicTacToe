using System;
namespace TicTacToeGame.Strategies
{
    public interface TicTacToeStrategy
    {
        bool CanHandle(TicTacToeGame.Cell[,] board);
        void Update(TicTacToeGame.Cell[,] board);
    }
}
