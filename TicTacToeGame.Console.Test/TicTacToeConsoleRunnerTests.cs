using System;
using Moq;
using NUnit.Framework;

namespace TicTacToeGame.Console.Test
{
    [TestFixture]
    public class TicTacToeConsoleRunnerTests
    {
        Mock<TicTacToe> ticTacToe;
        TicTacToeConsoleRunner ticTacToeConsoleRunner;

        [Test]
        public void TestInitialize()
        {
            ticTacToe = new Mock<TicTacToe>();
            ticTacToeConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object);
        }

        [Test]
        public void WhenThePlayerPlays_TheGameHandlesTheMove()
        {
            ticTacToeConsoleRunner.Play(0, 0);

            ticTacToe.Verify(ttt => ttt.OpponentMove(0, 0));
        }

        [Test]
        public void WhenThePlayerPlays_TheGamePlaysTheAI()
        {
            ticTacToeConsoleRunner.Play(0, 0);

            ticTacToe.Verify(ttt => ttt.AIMove());
        }

        [Test]
        public void WhenAskingForTheBoard_TheGameBoardIsReturned()
        {
            ticTacToe.SetupGet(ttt => ttt.Board).Returns(new Board());
            ticTacToeConsoleRunner.GetBoard();

            ticTacToe.VerifyGet(ttt => ttt.Board);
        }
    }
}