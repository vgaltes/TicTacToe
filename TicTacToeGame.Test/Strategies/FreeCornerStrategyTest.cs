using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Strategies;
using FluentAssertions;
using NUnit.Framework;

namespace TicTacToeGame.Test.Strategies
{
    [TestFixture]
    public class FreeCornerStrategyTest
    {
        private const char AI_MARK = 'X';
        private const char OPPONENTS_MARK = 'O';
        FreeCornerStrategy freeCornerStrategy = new FreeCornerStrategy(AI_MARK, OPPONENTS_MARK);

        [Test]
        public void GivenThereIsTheFirstCornerEmpty_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetAnEmptyBoard();

            var canHandle = freeCornerStrategy.CanHandle(initialBoard, AI_MARK);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenThereIsTheFirstCornerEmpty_TheAIPutTheMarkInTheFirstCorner()
        {
            var initialBoard = BoardTestHelper.GetAnEmptyBoard();

            freeCornerStrategy.Update(initialBoard, AI_MARK);

            var expectedBoard = BoardTestHelper.GetABoardWithAMark(Mark.AIFromCoordinates(0, 0));

            initialBoard.Should().Be(expectedBoard);
        }

        [Test]
        public void GivenThereIsAMarkInTheFirstCorner_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(0, 0));

            var canHandle = freeCornerStrategy.CanHandle(initialBoard, AI_MARK);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenThereIsAMarkInTheFirstCorner_TheAIPutTheMarkInTheSecondCorner()
        {
            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.OpponentFromCoordinates(0, 0));

            freeCornerStrategy.Update(initialBoard, AI_MARK);

            var expectedBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>
                {
                    Mark.OpponentFromCoordinates(0, 0),
                    Mark.AIFromCoordinates(0, 2)
                });

            initialBoard.Should().Be(expectedBoard);
        }

        [Test]
        public void GivenThereIsAMarkInTheTwoFirstCorners_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks( new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 2)
            });

            var canHandle = freeCornerStrategy.CanHandle(initialBoard, AI_MARK);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenThereIsAMarkInTheTwoFirstCorners_TheAIPutTheMarkInTheThirdCorner()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 2)
            });

            freeCornerStrategy.Update(initialBoard, AI_MARK);

            var expectedBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 2),
                Mark.AIFromCoordinates(2, 0)
            });

            initialBoard.Should().Be(expectedBoard);
        }

        [Test]
        public void GivenThereIsAMarkInTheThreeFirstCorners_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 2),
                Mark.OpponentFromCoordinates(2, 0)
            });

            var canHandle = freeCornerStrategy.CanHandle(initialBoard, AI_MARK);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenThereIsAMarkInTheThreeFirstCorners_TheAIPutTheMarkInTheFourthCorner()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 2),
                Mark.OpponentFromCoordinates(2, 0)
            });

            freeCornerStrategy.Update(initialBoard, AI_MARK);

            var expectedBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 2),
                Mark.OpponentFromCoordinates(2, 0),
                Mark.AIFromCoordinates(2, 2)
            });

            initialBoard.Should().Be(expectedBoard);
        }

        [Test]
        public void GivenThereIsAMarkInAllCorners_CanHandleReturnsFalse()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 2),
                Mark.OpponentFromCoordinates(2, 0),
                Mark.OpponentFromCoordinates(2, 2)
            });

            var canHandle = freeCornerStrategy.CanHandle(initialBoard, AI_MARK);

            canHandle.Should().BeFalse();
        }
    }
}