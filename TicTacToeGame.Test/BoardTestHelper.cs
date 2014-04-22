using System.Collections.Generic;
using TicTacToeGame.Models;
namespace TicTacToeGame.Test
{
    public static class BoardTestHelper
    {
        private const char AI_MARK = 'X';
        private const char OPPONENTS_MARK = 'O';
        private const char EMPTY_MARK = ' ';

        public static Board GetAnEmptyBoard()
        {
            return GetABoardWithAMarkInTheCenterOfType(EMPTY_MARK);
        }

        public static Board GetABoardWithAMarkInTheCenterOfType(char mark)
        {
            return GetABoardWithAMark(new Mark(mark, new CellCoordinates(1,1)));
        }

        public static Board GetABoardWithAMark(Mark mark)
        {
            return GetABoardWithMarks(new List<Mark> { mark });
        }

        internal static Board GetABoardWithMarks(List<Mark> marks)
        {
            var board = new Board();

            foreach (var mark in marks)
            {
                board.FillCell(mark.CellCoordinate, mark.Cell);
            }

            return board;
        }
    }
}