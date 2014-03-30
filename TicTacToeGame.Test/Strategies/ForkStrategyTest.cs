using NUnit.Framework;
using FluentAssertions;
using TicTacToeGame.Strategies;
using System.Collections.Generic;

namespace TicTacToeGame.Test.Strategies
{
    [TestFixture]
    public class ForkStrategyTest
    {
        ForkStrategy forkStrategy = new ForkStrategy();

        [Test]
        public void GivenAnEmptyBoard_CanHandleReturnsFalse()
        {
            var initialBoard = BoardTestHelper.GetAnEmptyBoard();

            var canHandle = forkStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [Test]
        public void GivenABoarkWithOneAIMark_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.AIFromCoordinates(0, 0));

            var canHandle = forkStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenABoarkWithTwoAIMarkInALine_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>{
                Mark.AIFromCoordinates(0, 0),
                Mark.AIFromCoordinates(0, 1)
            });

            var canHandle = forkStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenABoardWithAIMarksInFirstAndFourthCornerAndOpponentMarkInCenter_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>{
                Mark.AIFromCoordinates(0, 0),
                Mark.AIFromCoordinates(2, 2),
                Mark.OpponentFromCoordinates(1,1)
            });

            var canHandle = forkStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenABoardWithAIMarksInAllCornersAndOpponentMarkInCenter_CanHandleReturnsFalse()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>{
                Mark.AIFromCoordinates(0, 0),
                Mark.AIFromCoordinates(2, 2),
                Mark.AIFromCoordinates(0, 2),
                Mark.AIFromCoordinates(2, 0),
                Mark.OpponentFromCoordinates(1,1)
            });

            var canHandle = forkStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [Test]
        public void GivenABoardWithAIMarksInACornerAndASideAndOpponentMarkInACornerAndASide_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>{
                Mark.AIFromCoordinates(0, 0),
                Mark.AIFromCoordinates(1, 2),
                Mark.OpponentFromCoordinates(0,1),
                Mark.OpponentFromCoordinates(2,2)
            });

            var canHandle = forkStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }
    }
}