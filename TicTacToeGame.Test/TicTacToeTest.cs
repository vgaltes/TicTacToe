using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TicTacToeGame.Models;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test
{
    [TestFixture]
    public class TicTacToeTest
    {
        [Test]
        public void WhenThePlayerPlays_TheGamePlaysTheAI()
        {
            var board = new Mock<Board>();
            var ticTacToe = new TicTacToe(board.Object, new List<TicTacToeStrategy>());

            ticTacToe.OpponentMove(new Models.CellCoordinates(0, 0));

            board.Verify(b => b.FillAICell(It.IsAny<CellCoordinates>()));
        }
    }
}
