using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using FluentAssertions;
using NUnit.Framework;
using TicTacToeGame.Models;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Strategies
{
    [TestFixture]
    public class WinStrategyTest
    {
        private const char AI_MARK = 'X';
        private const char OPPONENTS_MARK = 'O';

        WinStrategy winStrategy = new WinStrategy(AI_MARK, OPPONENTS_MARK);
               

        [Test, TestCaseSource("GetTestDataForRows")]
        public void TestCanHandle_ForRows(TestLine line)
        {
            TestCanHandleLine(line);
        }

        [Test, TestCaseSource("GetTestDataForColumns")]
        public void TestCanHandle_ForColumns(TestLine line)
        {
            TestCanHandleLine(line);
        }

        [Test, TestCaseSource("GetTestDataForDiagonals")]
        public void TestCanHandle_ForDiagonals(TestLine line)
        {
            TestCanHandleLine(line);
        }

        [Test, TestCaseSource("GetTestDataForRows")]
        public void TestUpdate_ForRows(TestLine line)
        {
            TestUpdateLine(line);
        }

        [Test, TestCaseSource("GetTestDataForColumns")]
        public void TestUpdate_ForColumns(TestLine line)
        {
            TestUpdateLine(line);
        }

        [Test, TestCaseSource("GetTestDataForDiagonals")]
        public void TestUpdate_ForDiagonals(TestLine line)
        {
            TestUpdateLine(line);
        }

        private void TestCanHandleLine(TestLine line)
        {
            Mark startMark = Mark.AIFromCoordinates(line.RowStart, line.ColumnStart);
            Mark endMark = Mark.AIFromCoordinates(line.RowEnd, line.ColumnEnd);

            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                startMark,
                endMark
             });

            var cellValue = line.EvaluateValue == "AI" ? AI_MARK : ' ';

            initialBoard.FillCell(new CellCoordinates(line.RowEvaluate, line.ColumnEvaluate), cellValue);

            var canHandle = winStrategy.CanHandle(initialBoard, AI_MARK);

            canHandle.Should().Be(line.ExpectedCanHandleValue);
        }

        private void TestUpdateLine(TestLine line)
        {
            Mark startMark = Mark.AIFromCoordinates(line.RowStart, line.ColumnStart);
            Mark endMark = Mark.AIFromCoordinates(line.RowEnd, line.ColumnEnd);

            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> {
                startMark,
                endMark
             });

            if (line.ExpectedCanHandleValue)
            {
                winStrategy.Update(initialBoard, AI_MARK);
                initialBoard.IsCellOfType(AI_MARK, new CellCoordinates(line.RowEvaluate, line.ColumnEvaluate));
            }
        }

        private IEnumerable<TestLine> GetTestDataForRows()
        {
            return GetTestData(@"TestData\TestRows.xml");
        }

        private IEnumerable<TestLine> GetTestDataForColumns()
        {
            return GetTestData(@"TestData\TestColumns.xml");
        }

        private IEnumerable<TestLine> GetTestDataForDiagonals()
        {
            return GetTestData(@"TestData\TestDiagonals.xml");
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