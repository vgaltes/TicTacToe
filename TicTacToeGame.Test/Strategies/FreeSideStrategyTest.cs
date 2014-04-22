using FluentAssertions;
using TicTacToeGame.Strategies;
using NUnit.Framework;
using TicTacToeGame.Models;
using System.Collections.Generic;

namespace TicTacToeGame.Test.Strategies
{
    [TestFixture]
    public class FreeSideStrategyTest
    {
        private const char AI_MARK = 'X';
        private const char OPPONENTS_MARK = 'O';

        FreeSideStrategy freeSideStrategy = new FreeSideStrategy(AI_MARK, OPPONENTS_MARK);

        [Test]
        public void GivenTheFirstSideFree_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> { new Mark(OPPONENTS_MARK, new CellCoordinates(0, 0)) });

            var canHandle = freeSideStrategy.CanHandle(initialBoard, AI_MARK);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenTheFirstSideFree_UpdatePutsAMarkInTheFirstSide()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> { new Mark(OPPONENTS_MARK, new CellCoordinates(0, 0)) });

            freeSideStrategy.Update(initialBoard, AI_MARK);

            initialBoard.IsCellOfType(AI_MARK, new CellCoordinates(0, 1)).Should().BeTrue();
        }

        [Test]
        public void GivenTheSecondSideFree_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> { new Mark(OPPONENTS_MARK, new CellCoordinates(0, 1)) });

            var canHandle = freeSideStrategy.CanHandle(initialBoard, AI_MARK);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenTheSecondSideFree_UpdatePutsAMarkInTheSeconSide()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> { new Mark(OPPONENTS_MARK, new CellCoordinates(0, 1)) });

            freeSideStrategy.Update(initialBoard, AI_MARK);

            initialBoard.IsCellOfType(AI_MARK, new CellCoordinates(1, 0)).Should().BeTrue();
        }

        [Test]
        public void GivenTheThirdSideFree_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> 
            { 
                new Mark(OPPONENTS_MARK, new CellCoordinates(0, 1)),
                new Mark(OPPONENTS_MARK, new CellCoordinates(1, 0))
            });

            var canHandle = freeSideStrategy.CanHandle(initialBoard, AI_MARK);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenTheThirdSideFree_UpdatePutsAMarkInTheThirdSide()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> 
            { 
                new Mark(OPPONENTS_MARK, new CellCoordinates(0, 1)),
                new Mark(OPPONENTS_MARK, new CellCoordinates(1, 0))
            });

            freeSideStrategy.Update(initialBoard, AI_MARK);

            initialBoard.IsCellOfType(AI_MARK, new CellCoordinates(1, 2)).Should().BeTrue();
        }

        [Test]
        public void GivenTheFourthSideFree_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> 
            { 
                new Mark(OPPONENTS_MARK, new CellCoordinates(0, 1)),
                new Mark(OPPONENTS_MARK, new CellCoordinates(1, 0)),
                new Mark(OPPONENTS_MARK, new CellCoordinates(1, 2))
            });

            var canHandle = freeSideStrategy.CanHandle(initialBoard, AI_MARK);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenTheFourthSideFree_UpdatePutsAMarkInTheFourthSide()
        {
            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark> 
            { 
                new Mark(OPPONENTS_MARK, new CellCoordinates(0, 1)),
                new Mark(OPPONENTS_MARK, new CellCoordinates(1, 0)),
                new Mark(OPPONENTS_MARK, new CellCoordinates(1, 2))
            });

            freeSideStrategy.Update(initialBoard, AI_MARK);

            initialBoard.IsCellOfType(AI_MARK, new CellCoordinates(2, 1)).Should().BeTrue();
        }
    }
}