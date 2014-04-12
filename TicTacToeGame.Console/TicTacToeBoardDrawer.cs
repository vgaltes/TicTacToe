using TicTacToeGame.Models;
namespace TicTacToeGame.Console
{
    public class TicTacToeBoardDrawer
    {
        public string GetRepresentationOf(Board board)
        {            
            return string.Format("{0}|{1}|{2}\n-----\n{3}|{4}|{5}\n-----\n{6}|{7}|{8}",
                Draw(board[0, 0]), Draw(board[0, 1]), Draw(board[0, 2]),
                Draw(board[1, 0]), Draw(board[1, 1]), Draw(board[1, 2]),
                Draw(board[2, 0]), Draw(board[2, 1]), Draw(board[2, 2]));
        }

        private string Draw(CellType cell)
        {
            if (cell == CellType.AI)
                return "X";
            if (cell == CellType.Opponent)
                return "O";
            return " ";
        }
    }
}