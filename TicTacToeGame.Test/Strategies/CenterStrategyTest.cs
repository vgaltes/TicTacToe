using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Strategies
{
    [TestClass]
    public class CenterStrategyTest
    {
        [TestMethod]
        public void GivenTheCenterIsFree_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetAnEmptyBoard();

            var centerStrategy = new CenterStrategy();
            var canHandle = centerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [TestMethod]
        public void GivenTheCenterIsNotFree_CanHandleReturnsFalse()
        {
            var initialBoard = BoardTestHelper.GetABoardWithAMarkInTheCenterOfType(Cell.Opponent);

            var centerStrategy = new CenterStrategy();
            var canHandle = centerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [TestMethod]
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