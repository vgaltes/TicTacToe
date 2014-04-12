using NUnit.Framework;
using TicTacToeGame.Exceptions;
using TicTacToeGame.Models;

namespace TicTacToeGame.Test
{
    [TestFixture]
    public class BoardTest
    {
        [Test, ExpectedException(ExpectedException=typeof(NotAllowedMovementException))]
        public void GivenABoardWithAnOpponentCell_WhenPuttingAnOpponentCellInTheSameCell_NotAllowedMovementExceptionIsThrown()
        {
            var board = new Board();
            var cellCoordinates = new CellCoordinates(0,0);
            board.FillOpponentCell(cellCoordinates);

            board.FillOpponentCell(cellCoordinates);
        }
    }
}