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

            var expectedBoard = BoardTestHelper.GetABoardWithAMark(Mark.AIFromCoordinates(0, 0));

            initialBoard.Should().ContainInOrder(expectedBoard);
        }

        [TestMethod]
        public void GivenThereIsAMarkInTheFirstCorner_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(0, 0));

            var freeCornerStrategy = new FreeCornerStrategy();
            var canHandle = freeCornerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [TestMethod]
        public void GivenThereIsAMarkInTheFirstCorner_TheAIPutTheMarkInTheSecondCorner()
        {
            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(0, 0));

            var freeCornerStrategy = new FreeCornerStrategy();
            freeCornerStrategy.Update(initialBoard);

            var expectedBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>
                {
                    Mark.OpponentFromCoordinates(0, 0),
                    Mark.AIFromCoordinates(0, 2)
                });

            initialBoard.Should().ContainInOrder(expectedBoard);
        }

        [TestMethod]
        public void GivenThereIsAMarkInTheTwoFirstCorners_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks( new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 2)
            });

            var freeCornerStrategy = new FreeCornerStrategy();
            var canHandle = freeCornerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [TestMethod]
        public void GivenThereIsAMarkInTheTwoFirstCorners_TheAIPutTheMarkInTheThirdCorner()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 2)
            });

            var freeCornerStrategy = new FreeCornerStrategy();
            freeCornerStrategy.Update(initialBoard);

            var expectedBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 2),
                Mark.OpponentFromCoordinates(2, 0)
            });

            initialBoard.Should().ContainInOrder(expectedBoard);
        }
    }
}
