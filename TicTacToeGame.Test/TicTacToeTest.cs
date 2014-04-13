using System.Collections.Generic;
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

            ticTacToe.OpponentMove(new Models.CellCoordinates(1, 1));

            board.Verify(b => b.FillAICell(It.IsAny<CellCoordinates>()));
        }
    }
}