using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Strategies
{
    [TestFixture]
    public class OppositeCornerStrategyTest
    {
        [Test]
        public void GivenThereIsAnOpponentInTheFirstCorner_CanHandleReturnsTrue()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(0, 0));
            var canHandle = oppositeCornerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenThereIsAnOpponentInTheFirstCorner_TheAIPutsTheMarkInTheFourthCorner()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(0, 0));
            oppositeCornerStrategy.Update(initialBoard);

            var expectedBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>
                {
                    Mark.OpponentFromCoordinates(0, 0),
                    Mark.AIFromCoordinates(2, 2)
                });

            initialBoard.Should().Be(expectedBoard);
        }

        [Test]
        public void GivenThereIsAnOpponentInTheSecondCorner_CanHandleReturnsTrue()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(0, 2));

            var canHandle = oppositeCornerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenThereIsAnOpponentInTheSecondCorner_TheAIPutsTheMarkInTheThirdCorner()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(0, 2));

            oppositeCornerStrategy.Update(initialBoard);

            var expectedBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>
                {
                    Mark.OpponentFromCoordinates(0, 2),
                    Mark.AIFromCoordinates(2, 0)
                });

            initialBoard.Should().Be(expectedBoard);
        }

        [Test]
        public void GivenThereIsAnOpponentInTheThirdCorner_CanHandleReturnsTrue()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(2, 0));

            var canHandle = oppositeCornerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenThereIsAnOpponentInTheThirdCorner_TheAIPutsTheMarkInTheSecondCorner()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(2, 0));

            oppositeCornerStrategy.Update(initialBoard);

            var expectedBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>
                {
                    Mark.OpponentFromCoordinates(2, 0),
                    Mark.AIFromCoordinates(0, 2)
                });

            initialBoard.Should().Be(expectedBoard);
        }

        [Test]
        public void GivenThereIsAnOpponentInTheFourthCorner_CanHandleReturnsTrue()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(2, 2));

            var canHandle = oppositeCornerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenThereIsAnOpponentInTheFourthCorner_TheAIPutsTheMarkInTheFirstCorner()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(2, 2));

            oppositeCornerStrategy.Update(initialBoard);

            var expectedBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>
                {
                    Mark.OpponentFromCoordinates(2, 2),
                    Mark.AIFromCoordinates(0, 0)
                });

            initialBoard.Should().Be(expectedBoard);
        }

        [Test]
        public void GivenAnEmptyBoard_CanHandleReturnsFalse()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetAnEmptyBoard();

            var canHandle = oppositeCornerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [Test]
        public void GivenThereIsAnOpponentInTheFirstAndFourthCorner_CanHandleReturnsFalse()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>{
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(2, 2)});

            var canHandle = oppositeCornerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [Test]
        public void GivenThereIsAnOpponentInTheFirstAndSecondCorner_TheAIPutsTheMarkInTheThirdCorner()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>
            {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 2)
            });

            oppositeCornerStrategy.Update(initialBoard);

            var expectedBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>
                {
                    Mark.OpponentFromCoordinates(0, 0),
                    Mark.OpponentFromCoordinates(0, 2),
                    Mark.AIFromCoordinates(2, 2)
                });

            initialBoard.Should().Be(expectedBoard);
        }
    }
}