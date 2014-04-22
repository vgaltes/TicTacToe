using FluentAssertions;
using NUnit.Framework;
using TicTacToeGame.Models;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Strategies
{
    [TestFixture]
    public class CenterStrategyTest
    {
        private const char AI_MARK = 'X';
        private const char OPPONENTS_MARK = 'O';
        CenterStrategy centerStrategy = new CenterStrategy(AI_MARK, OPPONENTS_MARK);

        [Test]
        public void GivenTheCenterIsFree_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetAnEmptyBoard();

            var canHandle = centerStrategy.CanHandle(initialBoard, AI_MARK);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenTheCenterIsNotFree_CanHandleReturnsFalse()
        {
            var initialBoard = BoardTestHelper.GetABoardWithAMarkInTheCenterOfType(OPPONENTS_MARK);

            var canHandle = centerStrategy.CanHandle(initialBoard, AI_MARK);

            canHandle.Should().BeFalse();
        }

        [Test]
        public void GivenTheCenterIsFree_UpdatePutsAMarkInTheCenter()
        {
            var initialBoard = BoardTestHelper.GetAnEmptyBoard();

            centerStrategy.Update(initialBoard, AI_MARK);

            var expectedBoard = BoardTestHelper.GetABoardWithAMarkInTheCenterOfType(AI_MARK);

            initialBoard.Should().Be(expectedBoard);
        }
    }
}