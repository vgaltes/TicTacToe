using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Strategies
{
    [TestClass]
    public class BlockStrategyTest
    {
        [TestMethod]
        public void GivenThereIsAMarkInAllCorners_CanHandleReturnsFalse()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 2),
                Mark.OpponentFromCoordinates(2, 0),
                Mark.OpponentFromCoordinates(2, 2)
            });

            var blockStrategy = new BlockStrategy();
            var canHandle = blockStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }
    }
}