using NUnit.Framework;
using TicTacToeGame.Strategies;
using FluentAssertions;

namespace TicTacToeGame.Test.Strategies
{
    [TestFixture]
    public class BlockForkStrategyTest
    {
        [Test]
        public void GivenThereIsAnAICellInTheFirstCorner_CanHandleReturnsTrue()
        {
            var blockForkStrategy = new BlockForkStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.AIFromCoordinates(0, 0));
            var canHandle = blockForkStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }
    }
}