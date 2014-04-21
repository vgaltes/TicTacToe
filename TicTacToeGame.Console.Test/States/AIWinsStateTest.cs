using Moq;
using NUnit.Framework;
using TicTacToeGame.Console.States;
using FluentAssertions;
using TicTacToeGame.Console.Players;

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

        [Test]
        public void ResetTicTacToe()
        {
            aiWinsState.Evaluate();

            ticTacToe.Verify(ttt => ttt.Reset(), Times.Once());
        }
    }
}