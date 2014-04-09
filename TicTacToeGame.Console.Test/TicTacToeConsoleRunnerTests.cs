using System;
using Moq;
using NUnit.Framework;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.Test
{
    [TestFixture]
    public class TicTacToeConsoleRunnerTests
    {
        Mock<ITicTacToe> ticTacToe;
        TicTacToeConsoleRunner ticTacToeConsoleRunner;

        [SetUp]
        public void TestInitialize()
        {
            ticTacToe = new Mock<ITicTacToe>();
            ticTacToeConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object);
        }

        [Test]
        public void WhenThePlayerPlays_TheGameHandlesTheMove()
        {
            var cellCoordinate = new MarkCoordinate(0, 0);
            ticTacToeConsoleRunner.Play(cellCoordinate);

            ticTacToe.Verify(ttt => ttt.OpponentMove(cellCoordinate));
        }

        [Test]
        public void WhenThePlayerPlays_TheGamePlaysTheAI()
        {
            ticTacToeConsoleRunner.Play(new MarkCoordinate(0, 0));

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