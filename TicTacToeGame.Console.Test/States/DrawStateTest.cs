using NUnit.Framework;
using FluentAssertions;
using Moq;
using TicTacToeGame.Console.States;
using TicTacToeGame.Console.Players;

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
        Mock<Player> player1;
        Mock<Player> player2;

        [SetUp]
        public void TestSetUp()
        {
            ticTacToe = new Mock<ITicTacToe>();
            ticTacToeBoardDrawer = new Mock<TicTacToeBoardDrawer>();
            consoleIO = new Mock<ConsoleIO>();
            player1 = new Mock<Player>();
            player2 = new Mock<Player>();
            tttConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, 
                ticTacToeBoardDrawer.Object, consoleIO.Object, player1.Object, player2.Object);

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
