using FluentAssertions;
using TicTacToeGame.Strategies;
using NUnit.Framework;

namespace TicTacToeGame.Test.Strategies
{
    [TestFixture]
    public class FreeSideStrategyTest
    {
        FreeSideStrategy freeSideStrategy = new FreeSideStrategy();

        [Test]
        public void GivenAFullBoard_CanHandleReturnsFalse()
        {
            var initialBoard = BoardTestHelper.GetAFullBoard();

            var canHandle = freeSideStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [Test]
        public void GivenTheFirstSideFree_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetAFullBoardWithAnEmptyCellAt(0,1);

            var canHandle = freeSideStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenTheFirstSideFree_UpdatePutsAMarkInTheFirstSide()
        {
            var initialBoard = BoardTestHelper.GetAFullBoardWithAnEmptyCellAt(0, 1);

            freeSideStrategy.Update(initialBoard);

            initialBoard.IsCellOfType(Cell.AI, 0, 1).Should().BeTrue();
        }

        [Test]
        public void GivenTheSecondSideFree_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetAFullBoardWithAnEmptyCellAt(1, 0);

            var canHandle = freeSideStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenTheSecondSideFree_UpdatePutsAMarkInTheSeconSide()
        {
            var initialBoard = BoardTestHelper.GetAFullBoardWithAnEmptyCellAt(1, 0);

            freeSideStrategy.Update(initialBoard);

            initialBoard.IsCellOfType(Cell.AI, 1, 0).Should().BeTrue();
        }

        [Test]
        public void GivenTheThirdSideFree_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetAFullBoardWithAnEmptyCellAt(1, 2);

            var canHandle = freeSideStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenTheThirdSideFree_UpdatePutsAMarkInTheThirdSide()
        {
            var initialBoard = BoardTestHelper.GetAFullBoardWithAnEmptyCellAt(1, 2);

            freeSideStrategy.Update(initialBoard);

            initialBoard.IsCellOfType(Cell.AI, 1, 2).Should().BeTrue();
        }

        [Test]
        public void GivenTheFourthSideFree_CanHandleReturnsTrue()
        {
            var initialBoard = BoardTestHelper.GetAFullBoardWithAnEmptyCellAt(2, 1);

            var canHandle = freeSideStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenTheFourthSideFree_UpdatePutsAMarkInTheFourthSide()
        {
            var initialBoard = BoardTestHelper.GetAFullBoardWithAnEmptyCellAt(2, 1);

            freeSideStrategy.Update(initialBoard);

            initialBoard.IsCellOfType(Cell.AI, 2, 1).Should().BeTrue();
        }
    }
}