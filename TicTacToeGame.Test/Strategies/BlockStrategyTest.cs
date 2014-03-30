﻿using System.Collections.Generic;
using FluentAssertions;
using TicTacToeGame.Strategies;
using System;
using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;

namespace TicTacToeGame.Test.Strategies
{
    [TestFixture]
    public class BlockStrategyTest
    {
        BlockStrategy blockStrategy = new BlockStrategy();

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
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

            var canHandle = blockStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [Test]
        public void GivenThereAreTwoMarksInARowStartingInFirstCorner_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 1)
            });

            var canHandle = blockStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
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

        [Test]
        public void GivenThereAreTwoMarksInARowStartingInFirstSide_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(0, 1),
                Mark.OpponentFromCoordinates(0, 2)
            });

            var canHandle = blockStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
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

        [Test]
        public void GivenThereAreTwoMarksInARowStartingInSecondSide_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                Mark.OpponentFromCoordinates(1, 0),
                Mark.OpponentFromCoordinates(1, 1)
            });

            var canHandle = blockStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test, TestCaseSource("GetTestDataForRows")]
        public void TestRows(TestLine line)
        {
            TestLine(line);
        }

        [Test, TestCaseSource("GetTestDataForColumns")]
        public void TestColumns(TestLine line)
        {
            TestLine(line);
        }

        private void TestLine(TestLine line)
        {
            Mark startMark = Mark.OpponentFromCoordinates(line.RowStart, line.ColumnStart);
            Mark endMark = Mark.OpponentFromCoordinates(line.RowEnd, line.ColumnEnd);

            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                startMark,
                endMark
             });

            initialBoard[line.RowEvaluate, line.ColumnEvaluate] = (Cell)Enum.Parse(typeof(Cell), line.EvaluateValue);

            var canHandle = blockStrategy.CanHandle(initialBoard);

            canHandle.Should().Be(line.ExpectedCanHandleValue);
        }

        private IEnumerable<TestLine> GetTestDataForRows()
        {
            return GetTestData(@"TestData\TestRows.xml");
        }

        private IEnumerable<TestLine> GetTestDataForColumns()
        {
            return GetTestData(@"TestData\TestColumns.xml");
        }
        
        private IEnumerable<TestLine> GetTestData(string fileName)
        {
            using ( var fileStreamReader = new StreamReader(fileName))
            {
                var serializer = new XmlSerializer(typeof(TestData));
                TestData lines = (TestData)serializer.Deserialize(fileStreamReader);

                foreach (var line in lines.Lines)
                    yield return line;
            }
        }
    }
}