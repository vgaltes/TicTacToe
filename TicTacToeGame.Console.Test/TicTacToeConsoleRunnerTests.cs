using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TicTacToeGame.Console.Test
{
    [TestClass]
    public class TicTacToeConsoleRunnerTests
    {
        [TestMethod]
        public void WhenThePlayerPlays_TheGameHandlesTheMove()
        {
            var ticTacToe = new Mock<TicTacToe>();
            var ticTacToeConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object);

            ticTacToeConsoleRunner.Play(0, 0);

            ticTacToe.Verify(ttt => ttt.OpponentMove(0, 0));
        }
    }
}
