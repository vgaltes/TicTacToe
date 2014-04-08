using NUnit.Framework;
using TicTacToeGame.Strategies;
using FluentAssertions;
using System.Collections.Generic;

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

        [Test]
        public void GivenThereAreCellsInTheFirstQuarter_CanHandleReturnsFalse()
        {
            var blockForkStrategy = new BlockForkStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>{
                Mark.AIFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 1),
                Mark.OpponentFromCoordinates(1, 0),
                Mark.OpponentFromCoordinates(1, 1),
            });

            var canHandle = blockForkStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }
    }
}