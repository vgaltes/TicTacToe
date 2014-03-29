using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Strategies
{
    [TestClass]
    public class OppositeCornerStrategyTest
    {
        [TestMethod]
        public void GivenThereIsAnOpponentInTheFirstCorner_CanHandleReturnsTrue()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(0, 0));
            var canHandle = oppositeCornerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [TestMethod]
        public void GivenThereIsAnOpponentInTheFirstCorner_TheAIPutsTheMarkInTheThirdCorner()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(0, 0));
            oppositeCornerStrategy.Update(initialBoard);

            var expectedBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>
                {
                    Mark.OpponentFromCoordinates(0, 0),
                    Mark.AIFromCoordinates(2, 2)
                });

            initialBoard.Should().ContainInOrder(expectedBoard);
        }

        [TestMethod]
        public void GivenThereIsAnOpponentInTheSecondCorner_CanHandleReturnsTrue()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(0, 2));

            var canHandle = oppositeCornerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [TestMethod]
        public void GivenThereIsAnOpponentInTheSecondCorner_TheAIPutsTheMarkInTheFourthCorner()
        {
            var oppositeCornerStrategy = new OppositeCornerStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(0, 2));

            oppositeCornerStrategy.Update(initialBoard);

            var expectedBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>
                {
                    Mark.OpponentFromCoordinates(0, 2),
                    Mark.AIFromCoordinates(2, 0)
                });

            initialBoard.Should().ContainInOrder(expectedBoard);
        }
    }
}