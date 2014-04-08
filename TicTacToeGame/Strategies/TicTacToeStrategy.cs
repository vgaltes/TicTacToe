using System;

namespace TicTacToeGame.Strategies
{
    public interface TicTacToeStrategy
    {
        bool CanHandle(Board board);

        void Update(Board board);
    }
}