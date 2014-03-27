using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TicTacToeGame.Console.Test
{
    [TestClass]
    public class TicTacToeConsoleRunnerTests
    {
        Mock<TicTacToe> ticTacToe;
        TicTacToeConsoleRunner ticTacToeConsoleRunner;

        [TestInitialize]
        public void TestInitialize()
        {
            ticTacToe = new Mock<TicTacToe>();
            ticTacToeConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object);
        }

        [TestMethod]
        public void WhenThePlayerPlays_TheGameHandlesTheMove()
        {
            ticTacToeConsoleRunner.Play(0, 0);

            ticTacToe.Verify(ttt => ttt.OpponentMove(0, 0));
        }

        [TestMethod]
        public void WhenThePlayerPlays_TheGamePlaysTheAI()
        {
            ticTacToeConsoleRunner.Play(0, 0);

            ticTacToe.Verify(ttt => ttt.AIMove());
        }

        [TestMethod]
        public void WhenAskingForTheBoard_TheGameBoardIsReturned()
        {
            ticTacToe.SetupGet(ttt => ttt.Board).Returns(new Cell[1, 1]);
            ticTacToeConsoleRunner.GetBoard();

            ticTacToe.VerifyGet(ttt => ttt.Board);
        }
    }
}
