using NUnit.Framework;
using TicTacToeGame.Exceptions;
using TicTacToeGame.Models;
using FluentAssertions;

namespace TicTacToeGame.Test
{
    [TestFixture]
    public class BoardTest
    {
        private const char AI_MARK = 'X';
        private const char OPPONENTS_MARK = 'O';
        private const char EMPTY_MARK = ' ';

        [Test, ExpectedException(ExpectedException=typeof(NotAllowedMovementException))]
        public void GivenABoardWithAnOpponentCell_WhenPuttingAnOpponentCellInTheSameCell_NotAllowedMovementExceptionIsThrown()
        {
            var board = new Board();
            var cellCoordinates = new CellCoordinates(0,0);
            board.FillCell(cellCoordinates, OPPONENTS_MARK);

            board.FillCell(cellCoordinates, OPPONENTS_MARK);
        }

        [Test, ExpectedException(ExpectedException = typeof(NotAllowedMovementException))]
        public void WhenPuttingAnOpponentCellOutsideTheBoard_NotAllowedMovementExceptionIsThrown()
        {
            var board = new Board();
            var cellCoordinates = new CellCoordinates(4, 4);
            board.FillCell(cellCoordinates, OPPONENTS_MARK);
        }

        [Test]
        public void GivenThreeOpponentMarksInALine_StateIsOpponentWins()
        {
            var board = new Board();

            board.FillCell(new CellCoordinates(0, 0), OPPONENTS_MARK);
            board.FillCell(new CellCoordinates(0, 1), OPPONENTS_MARK);
            board.FillCell(new CellCoordinates(0, 2), OPPONENTS_MARK);

            board.State.Should().Be(TicTacToeBoardState.SomeoneWins);
            board.Winner.Should().Be(OPPONENTS_MARK);
        }

        [Test]
        public void GivenThreeAIMarksInALine_StateIsOpponentWins()
        {
            var board = new Board();

            board.FillCell(new CellCoordinates(0, 0), AI_MARK);
            board.FillCell(new CellCoordinates(0, 1), AI_MARK);
            board.FillCell(new CellCoordinates(0, 2), AI_MARK);

            board.State.Should().Be(TicTacToeBoardState.SomeoneWins);
            board.Winner.Should().Be(AI_MARK);
        }

        [Test]
        public void GivenSomeoneWins_ResetPutsAllCellsEmptyAndStateToPlaying()
        {
            var board = new Board();

            board.FillCell(new CellCoordinates(0, 0), OPPONENTS_MARK);
            board.FillCell(new CellCoordinates(0, 1), OPPONENTS_MARK);
            board.FillCell(new CellCoordinates(0, 2), OPPONENTS_MARK);

            board.Reset();

            var expectedBoard = BoardTestHelper.GetAnEmptyBoard();

            board.State.Should().Be(TicTacToeBoardState.Playing);
            board.Winner.Should().Be(EMPTY_MARK);
        }

        [Test, ExpectedException(ExpectedException=typeof(NotAllowedMovementException))]
        public void GivenStateIsNotPlaying_FillCellThrowsNotAllowedMovementException()
        {
            var board = new Board();

            board.FillCell(new CellCoordinates(0, 0), OPPONENTS_MARK);
            board.FillCell(new CellCoordinates(0, 1), OPPONENTS_MARK);
            board.FillCell(new CellCoordinates(0, 2), OPPONENTS_MARK);

            board.FillCell(new CellCoordinates(1, 2), OPPONENTS_MARK);
        }
    }
}