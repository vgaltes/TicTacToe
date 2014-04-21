using Moq;
using NUnit.Framework;
using FluentAssertions;
using TicTacToeGame.Console.States;
using TicTacToeGame.Models;
using TicTacToeGame.Console.Players;

namespace TicTacToeGame.Console.Test.States
{
    [TestFixture]
    public class AskingForPlayerStateTest
    {
        private const string AI_PLAYER = "1";
        private const string HUMAN_PLAYER = "2";
        private const string INVALID_OPTION = "3";
        private const string NON_INTEGER_OPTION = "a";

        Mock<ITicTacToe>  ticTacToe;
        Mock<TicTacToeBoardDrawer> ticTacToeBoardDrawer;
        Mock<ConsoleIO> consoleIO;
        TicTacToeConsoleRunner tttConsoleRunner;
        AskingForPlayerState asking4PlayerState;
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

            asking4PlayerState = new AskingForPlayerState(tttConsoleRunner);
            tttConsoleRunner.State = asking4PlayerState;
        }

        [Test]
        public void IfUserChoosesAI_NextStateIsPlaying()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(AI_PLAYER);
            asking4PlayerState.Evaluate();

            tttConsoleRunner.State.Should().BeOfType(typeof(PlayingState));
        }

        [Test]
        public void IfUserChoosesAI_PlayingStateCurrentPlayerIsSettedWithPlayer1()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(AI_PLAYER);
            asking4PlayerState.Evaluate();

            ((PlayingState)tttConsoleRunner.State).CurrentPlayer.Should().Be(player1.Object);
        }

        [Test]
        public void IfUserChoosesOpponent_TicTacToeSetInitialPlayerIsCalledWitCellTypeOpponent()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(HUMAN_PLAYER);
            asking4PlayerState.Evaluate();

            ((PlayingState)tttConsoleRunner.State).CurrentPlayer.Should().Be(player2.Object);
        }

        [Test]
        public void IfUserChoosesNorOpponentNeitherAI_StateRemainsAskingForPlayer()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(INVALID_OPTION);
            asking4PlayerState.Evaluate();

            tttConsoleRunner.State.Should().BeOfType(typeof(AskingForPlayerState));
        }

        [Test]
        public void AskForPlayerOnlyOnce()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(AI_PLAYER);
            asking4PlayerState.Evaluate();

            consoleIO.Verify(c => c.WriteLine(Resources.SelectPlayer), Times.Once());
            consoleIO.Verify(c => c.ReadLine(), Times.Once());
        }

        [Test]
        public void IfUserChoosesNorOpponentNeitherAI_ExtraInfoIsSettedWithTheErrorInformation()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(INVALID_OPTION);
            asking4PlayerState.Evaluate();

            tttConsoleRunner.State.InfoFromPreviousStep.Should().Be(Resources.SelectPlayer_InvalidOption);
        }

        [Test]
        public void IfUserChoosesANonIntegerOption_ExtraInfoIsSettedWithTheErrorInformation()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(NON_INTEGER_OPTION);
            asking4PlayerState.Evaluate();

            tttConsoleRunner.State.InfoFromPreviousStep.Should().Be(Resources.SelectPlayer_InvalidOption);
        }
    }
}