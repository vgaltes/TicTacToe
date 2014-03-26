using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Strategies
{
    [TestClass]
    public class CenterStrategyTest
    {
        [TestMethod]
        public void GivenTheCenterIsFree_CanHandleReturnsTrue()
        {
            var initialBoard = GetEmptyBoard();

            var centerStrategy = new CenterStrategy();
            var canHandle = centerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [TestMethod]
        public void GivenTheCenterIsNotFree_CanHandleReturnsFalse()
        {
            var initialBoard = GetABoardWithAMarkInTheCenterOfType(Cell.Opponent);

            var centerStrategy = new CenterStrategy();
            var canHandle = centerStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [TestMethod]
        public void GivenTheCenterIsFree_UpdatePutsAMarkInTheCenter()
        {
            var initialBoard = GetEmptyBoard();

            var centerStrategy = new CenterStrategy();
            centerStrategy.Update(initialBoard);

            var expectedBoard = GetABoardWithAMarkInTheCenterOfType(Cell.AI);

            initialBoard.Should().BeEquivalentTo(expectedBoard);
        }

        private static Cell[,] GetEmptyBoard()
        {
            return GetABoardWithAMarkInTheCenterOfType(Cell.Empty);
        }

        private static Cell[,] GetABoardWithAMarkInTheCenterOfType(Cell cell)
        {
            var board = new Cell[3, 3]{{Cell.Empty, Cell.Empty, Cell.Empty},
                                                {Cell.Empty, cell, Cell.Empty},
                                                {Cell.Empty, Cell.Empty, Cell.Empty}};
            return board;
        }
    }
}
