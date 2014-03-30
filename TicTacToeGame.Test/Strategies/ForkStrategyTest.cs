using NUnit.Framework;
using FluentAssertions;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Strategies
{
    [TestFixture]
    public class ForkStrategyTest
    {
        [Test]
        public void GivenAnEmptyBoard_CanHandleReturnsFalse()
        {
            var forkStrategy = new ForkStrategy();

            var initialBoard = BoardTestHelper.GetAnEmptyBoard();

            var canHandle = forkStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }
    }
}