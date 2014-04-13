using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TicTacToeGame.Models;
using TicTacToeGame.Strategies;
using TicTacToeGame.Test.Fakes;

namespace TicTacToeGame.Test
{
    [TestFixture]
    public class TicTacToeTest
    {
        [Test]
        public void WhenThePlayerPlays_TheGamePlaysTheAI()
        {
            var board = new Mock<Board>();
            var ticTacToe = new TicTacToe(board.Object, 
                new List<TicTacToeStrategy> { new AllwaysUpdateStrategy() });

            ticTacToe.OpponentMove(new CellCoordinates(1, 1));

            board.Verify(b => b.FillAICell(It.IsAny<CellCoordinates>()));
        }

        [Test]
        public void GivenThreeOpponentMarksInALine_StateIsOpponentWins()
        {
            var ticTacToe = new TicTacToe(new Board(),
                new List<TicTacToeStrategy>());

            ticTacToe.OpponentMove(new CellCoordinates(0, 0));
            ticTacToe.OpponentMove(new CellCoordinates(0, 1));
            ticTacToe.OpponentMove(new CellCoordinates(0, 2));

            ticTacToe.State.Should().Be(TicTacToeState.OpponentWins);           
        }

        [Test]
        public void GivenThreeAIMarksInALine_StateIsAIWins()
        {
            var ticTacToe = new TicTacToe(new Board(),
                new List<TicTacToeStrategy> { new FillFirstRowStrategy() });

            ticTacToe.OpponentMove(new CellCoordinates(1, 0));
            ticTacToe.OpponentMove(new CellCoordinates(1, 1));
            ticTacToe.OpponentMove(new CellCoordinates(2, 0));

            ticTacToe.State.Should().Be(TicTacToeState.AIWins);
        }
    }
}