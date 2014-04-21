using NUnit.Framework;
using FluentAssertions;
using Moq;
using TicTacToeGame.Console.States;
using TicTacToeGame.Console.Players;

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

        [Test]
        public void ResetTicTacToe()
        {
            humanWinsState.Evaluate();

            ticTacToe.Verify(ttt => ttt.Reset(), Times.Once());
        }
    }
}