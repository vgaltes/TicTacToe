using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeGame.Strategies;
using System;

namespace TicTacToeGame.Test.Strategies
{
    [TestClass]
    public class BlockStrategyTest
    {
        BlockStrategy blockStrategy = new BlockStrategy();

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void GivenThereIsAMarkInAllCorners_CanHandleReturnsFalse()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 2),
                Mark.OpponentFromCoordinates(2, 0),
                Mark.OpponentFromCoordinates(2, 2)
            });

            var canHandle = blockStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [TestMethod]
        public void GivenThereAreTwoMarksInARowStartingInFirstCorner_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 1)
            });

            var canHandle = blockStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [TestMethod]
        public void GivenThereAreTwoMarksInARowStartingInFirstCornerAndTheThirdOneIsOccupied_CanHandleReturnsFalse()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 1),
                Mark.AIFromCoordinates(0,2)
            });

            var canHandle = blockStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [TestMethod]
        public void GivenThereAreTwoMarksInARowStartingInFirstSide_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 1),
                Mark.OpponentFromCoordinates(0, 2)
            });

            var canHandle = blockStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [TestMethod]
        public void GivenThereAreTwoMarksInARowStartingInFirstSideAndTheThirdOneIsOccupied_CanHandleReturnsFalse()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 1),
                Mark.OpponentFromCoordinates(0, 2),
                Mark.AIFromCoordinates(0,0)
            });

            var canHandle = blockStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [TestMethod]
        public void GivenThereAreTwoMarksInARowStartingInSecondSide_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(1, 0),
                Mark.OpponentFromCoordinates(1, 1)
            });

            var canHandle = blockStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [TestMethod]
        [DeploymentItem("TestData\\TestRows.xml", "TestData")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\TestData\\TestRows.xml", "TestRows", DataAccessMethod.Sequential)]
        public void TestRows()
        {
            Mark startMark = Mark.OpponentFromCoordinates(Convert.ToInt32(TestContext.DataRow["RowStart"]),
                Convert.ToInt32(TestContext.DataRow["ColumnStart"]));
            Mark endMark = Mark.OpponentFromCoordinates(Convert.ToInt32(TestContext.DataRow["RowEnd"]),
                Convert.ToInt32(TestContext.DataRow["ColumnEnd"]));

            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                startMark,
                endMark
            });

            if (!(string.IsNullOrWhiteSpace(TestContext.DataRow["EvaluateValue"].ToString())))
                initialBoard[Convert.ToInt32(TestContext.DataRow["RowEvaluate"]),
                    Convert.ToInt32(TestContext.DataRow["ColumneEvaluate"])] = 
                        (Cell)Enum.Parse(typeof(Cell), TestContext.DataRow["EvaluateValue"].ToString());

            var canHandle = blockStrategy.CanHandle(initialBoard);

            canHandle.Should().Be(bool.Parse(TestContext.DataRow["ExpectedValue"].ToString()));
        }
    }
}