using NUnit.Framework;
using FluentAssertions;
using Moq;
using TicTacToeGame.Console.States;

namespace TicTacToeGame.Console.Test.States
{
    [TestFixture]
    public class DrawStateTest
    {
        Mock<ITicTacToe> ticTacToe;
        Mock<TicTacToeBoardDrawer> ticTacToeBoardDrawer;
        Mock<ConsoleIO> consoleIO;
        TicTacToeConsoleRunner tttConsoleRunner;
        DrawState drawState;

        [SetUp]
        public void TestSetUp()
        {
            ticTacToe = new Mock<ITicTacToe>();
            ticTacToeBoardDrawer = new Mock<TicTacToeBoardDrawer>();
            consoleIO = new Mock<ConsoleIO>();
            tttConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, ticTacToeBoardDrawer.Object, consoleIO.Object);

            drawState = new DrawState(tttConsoleRunner);
            tttConsoleRunner.State = drawState;
        }

        [Test]
        public void ShowsDrawMessage()
        {
            drawState.Evaluate();

            consoleIO.Verify(c => c.WriteLine(Resources.Draw));
        }

        [Test]
        public void WhenUserPressAKey_NextStateIsAskingForPlayer()
        {
            drawState.Evaluate();

            consoleIO.Verify(c => c.ReadKey(), Times.Once());
            tttConsoleRunner.State.Should().BeOfType<AskingForPlayerState>();
        }

        [Test]
        public void ResetTicTacToe()
        {
            drawState.Evaluate();

            ticTacToe.Verify(ttt => ttt.Reset(), Times.Once());
        }
    }
}
