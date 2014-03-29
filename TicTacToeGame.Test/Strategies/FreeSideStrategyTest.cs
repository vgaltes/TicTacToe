using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Strategies
{
    [TestClass]
    public class FreeSideStrategyTest
    {
        FreeSideStrategy freeSideStrategy = new FreeSideStrategy();

        [TestMethod]
        public void GivenAFullBoard_CanHandleReturnsFalse()
        {
            var initialBoard = BoardTestHelper.GetAFullBoard();

            var canHandle = freeSideStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [TestMethod]
        public void GivenTheFirstSideFree_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetAFullBoardWithAnEmptyCellAt(0,1);

            var canHandle = freeSideStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [TestMethod]
        public void GivenTheSecondSideFree_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetAFullBoardWithAnEmptyCellAt(1, 0);

            var canHandle = freeSideStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [TestMethod]
        public void GivenTheThirdSideFree_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetAFullBoardWithAnEmptyCellAt(1, 2);

            var canHandle = freeSideStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }
    }
}