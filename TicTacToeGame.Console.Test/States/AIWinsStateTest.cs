using Moq;
using NUnit.Framework;
using TicTacToeGame.Console.States;
using FluentAssertions;

namespace TicTacToeGame.Console.Test.States
{
    [TestFixture]
    public class AIWinsStateTest
    {
        Mock<ITicTacToe> ticTacToe;
        Mock<TicTacToeBoardDrawer> ticTacToeBoardDrawer;
        Mock<ConsoleIO> consoleIO;
        TicTacToeConsoleRunner tttConsoleRunner;
        AIWinsState aiWinsState;

        [SetUp]
        public void TestSetUp()
        {
            ticTacToe = new Mock<ITicTacToe>();
            ticTacToeBoardDrawer = new Mock<TicTacToeBoardDrawer>();
            consoleIO = new Mock<ConsoleIO>();
            tttConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, ticTacToeBoardDrawer.Object, consoleIO.Object);

            aiWinsState = new AIWinsState(tttConsoleRunner);
            tttConsoleRunner.State = aiWinsState;
        }

        [Test]
        public void ShowsWinMessage()
        {
            aiWinsState.Evaluate();

            consoleIO.Verify(c => c.WriteLine(Resources.AiWins));
        }

        [Test]
        public void WhenUserPressAKey_NextStateIsAskingForPlayer()
        {
            aiWinsState.Evaluate();

            tttConsoleRunner.State.Should().BeOfType<AskingForPlayerState>();
        }
    }
}