using NUnit.Framework;
using FluentAssertions;
using Moq;
using TicTacToeGame.Console.States;

namespace TicTacToeGame.Console.Test.States
{
    [TestFixture]
    public class HumanWinsStateTest
    {
        Mock<ITicTacToe> ticTacToe;
        Mock<TicTacToeBoardDrawer> ticTacToeBoardDrawer;
        Mock<ConsoleIO> consoleIO;
        TicTacToeConsoleRunner tttConsoleRunner;
        HumanWinsState humanWinsState;

        [SetUp]
        public void TestSetUp()
        {
            ticTacToe = new Mock<ITicTacToe>();
            ticTacToeBoardDrawer = new Mock<TicTacToeBoardDrawer>();
            consoleIO = new Mock<ConsoleIO>();
            tttConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, ticTacToeBoardDrawer.Object, consoleIO.Object);

            humanWinsState = new HumanWinsState(tttConsoleRunner);
            tttConsoleRunner.State = humanWinsState;
        }

        [Test]
        public void ShowsWinMessage()
        {
            humanWinsState.Evaluate();

            consoleIO.Verify(c => c.WriteLine(Resources.YouWin));
        }

        [Test]
        public void WhenUserPressAKey_NextStateIsAskingForPlayer()
        {
            humanWinsState.Evaluate();

            consoleIO.Verify(c => c.ReadKey(), Times.Once());
            tttConsoleRunner.State.Should().BeOfType<AskingForPlayerState>();
        }
    }
}