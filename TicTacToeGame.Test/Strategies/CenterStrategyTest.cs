using FluentAssertions;
using NUnit.Framework;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Strategies
{
    [TestFixture]
    public class CenterStrategyTest
    {
        [Test]
        public void GivenTheCenterIsFree_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetAnEmptyBoard();

            var centerStrategy = new CenterStrategy();
            var canHandle = centerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenTheCenterIsNotFree_CanHandleReturnsFalse()
        {
            var initialBoard = BoardTestHelper.GetABoardWithAMarkInTheCenterOfType(Cell.Opponent);

            var centerStrategy = new CenterStrategy();
            var canHandle = centerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [Test]
        public void GivenTheCenterIsFree_UpdatePutsAMarkInTheCenter()
        {
            var initialBoard = BoardTestHelper.GetAnEmptyBoard();

            var centerStrategy = new CenterStrategy();
            centerStrategy.Update(initialBoard);

            var expectedBoard = BoardTestHelper.GetABoardWithAMarkInTheCenterOfType(Cell.AI);

            initialBoard.Should().ContainInOrder(expectedBoard);
        }
    }
}