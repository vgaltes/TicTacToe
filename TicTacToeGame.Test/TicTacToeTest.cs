using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TicTacToeGame.Exceptions;
using TicTacToeGame.Models;
using TicTacToeGame.Strategies;
using TicTacToeGame.Test.Fakes;

namespace TicTacToeGame.Test
{
    [TestFixture]
    public class TicTacToeTest
    {        
        [Test]
        public void GivenThreeOpponentMarksInALine_StateIsOpponentWins()
        {
            ITicTacToe ticTacToe = new TicTacToe(new Board(),
                new List<TicTacToeStrategy>());

            ticTacToe.HumanMove(new CellCoordinates(0, 0));
            ticTacToe.HumanMove(new CellCoordinates(0, 1));
            ticTacToe.HumanMove(new CellCoordinates(0, 2));

            ticTacToe.State.Should().Be(TicTacToeState.OpponentWins);           
        }

        [Test]
        public void GivenThreeAIMarksInALine_StateIsAIWins()
        {
            ITicTacToe ticTacToe = new TicTacToe(new Board(),
                new List<TicTacToeStrategy> { new FillFirstRowStrategy() });

            ticTacToe.AIMove();
            ticTacToe.AIMove();
            ticTacToe.AIMove();

            ticTacToe.State.Should().Be(TicTacToeState.AIWins);
        }

        [Test, ExpectedException(ExpectedException=typeof(NotAllowedMovementException))]
        public void GivenTheStateIsNotPlaying_WhenOpponentMoves_MovementNotAllowedExceptionIsThrown()
        {
            var board = new Mock<Board>();
            ITicTacToe ticTacToe = new TicTacToe(board.Object,
                new List<TicTacToeStrategy> { new FillFirstRowStrategy() });

            ticTacToe.HumanMove(new CellCoordinates(1, 0));
            ticTacToe.HumanMove(new CellCoordinates(1, 1));
            ticTacToe.HumanMove(new CellCoordinates(1, 2));

            ticTacToe.HumanMove(new CellCoordinates(2, 0));
        }

        [Test]
        public void GivenSomeoneWins_ResetPutsAllCellsEmptyAndStateToPlaying()
        {
            ITicTacToe ticTacToe = new TicTacToe(new Board(),
                new List<TicTacToeStrategy>());

            ticTacToe.HumanMove(new CellCoordinates(0, 0));
            ticTacToe.HumanMove(new CellCoordinates(0, 1));
            ticTacToe.HumanMove(new CellCoordinates(0, 2));

            ticTacToe.Reset();
            
            ticTacToe.State.Should().Be(TicTacToeState.Playing);

            var expectedBoard = BoardTestHelper.GetAnEmptyBoard();

            ticTacToe.Board.Should().Be(expectedBoard);
        }

        [Test]
        public void WhenSettingInitialPlayerToAi_TheGamePlaysAI()
        {
            var board = new Mock<Board>();
            ITicTacToe ticTacToe = new TicTacToe(board.Object,
                new List<TicTacToeStrategy> { new AllwaysUpdateStrategy() });

            ticTacToe.SetInitialPlayer(CellType.AI);

            board.Verify(b => b.FillAICell(It.IsAny<CellCoordinates>()), Times.Once);
        }
    }
}