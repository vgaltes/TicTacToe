using System;

namespace TicTacToeGame.Strategies
{
    public abstract class TicTacToeStrategy
    {
        protected char myMark;
        protected char opponentsMark;

        public TicTacToeStrategy(char myMark, char opponentsMark)
        {
            this.myMark = myMark;
            this.opponentsMark = opponentsMark;
        }

        abstract public bool CanHandle(Board board, char mark);

        abstract public void Update(Board board, char mark);        
    }
}