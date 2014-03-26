using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeGame.Strategies;
using FluentAssertions;

namespace TicTacToeGame.Test.Strategies
{
    [TestClass]
    public class FreeCornerStrategyTest
    {
        [TestMethod]
        public void GivenThereIsTheFirstCornerEmpty_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetEmptyBoard();

            var freeCornerStrategy = new FreeCornerStrategy();
            var canHandle = freeCornerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [TestMethod]
        public void GivenThereIsTheFirstCornerEmpty_TheAIPutTheMarkInTheFirstCorner()
        {
            var initialBoard = BoardTestHelper.GetEmptyBoard();

            var freeCornerStrategy = new FreeCornerStrategy();
            freeCornerStrategy.Update(initialBoard);

            var expectedBoard = BoardTestHelper.GetABoardWithAMark(0, 0, Cell.AI);

            initialBoard.Should().BeEquivalentTo(expectedBoard);
        }
    }
}
