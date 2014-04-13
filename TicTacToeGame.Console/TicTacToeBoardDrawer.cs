using TicTacToeGame.Models;
namespace TicTacToeGame.Console
{
    public class TicTacToeBoardDrawer
    {
        private const string COLUMNS_SEPARATOR = "|";
        private const string ROWS_SEPARATOR = "-";
        private const string NEW_LINE = "\n";

        public string GetRepresentationOf(Board board)
        {
            string boardRepresentation = string.Empty;

            for (int row = 0; row < board.NumberOfRows; row++ )
            {
                boardRepresentation += DrawDataRow(board, row);
                boardRepresentation += DrawSeparatorRow(board, row);
            }

            return boardRepresentation;
        }

        private string DrawDataRow(Board board, int row)
        {
            var boardRepresentation = string.Empty;

            for (int column = 0; column < board.NumberOfColumns; column++)
            {
                boardRepresentation += Draw(board[row, column]);
                if (IsNotLastColumn(board, column))
                    boardRepresentation += COLUMNS_SEPARATOR;
            }

            return boardRepresentation;
        }

        private static string DrawSeparatorRow(Board board, int row)
        {
            var boardRepresentation = string.Empty;

            if (IsNotLastRow(board, row))
            {
                boardRepresentation += NEW_LINE;
                for (int column = 0; column < board.NumberOfColumns; column++)
                {
                    boardRepresentation += ROWS_SEPARATOR;
                    if (IsNotLastColumn(board, column))
                        boardRepresentation += ROWS_SEPARATOR;
                }
                boardRepresentation += NEW_LINE;
            }
            return boardRepresentation;
        }

        private static bool IsNotLastColumn(Board board, int column)
        {
            return column < board.NumberOfColumns - 1;
        }

        private static bool IsNotLastRow(Board board, int row)
        {
            return row < board.NumberOfRows - 1;
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