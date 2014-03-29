using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Strategies
{
    [TestClass]
    public class FreeSideStrategyTest
    {
        [TestMethod]
        public void GivenAFullBoard_CanHandleReturnsFalse()
        {
            var freeSideStrategy = new FreeSideStrategy();

            var initialBoard = BoardTestHelper.GetFullBoard();

            var canHandle = freeSideStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }
    }
}