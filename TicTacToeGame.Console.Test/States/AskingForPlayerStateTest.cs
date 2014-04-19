using Moq;
using NUnit.Framework;
using FluentAssertions;
using TicTacToeGame.Console.States;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.Test.States
{
    [TestFixture]
    public class AskingForPlayerStateTest
    {
        private const string AI_PLAYER = "1";
        private const string HUMAN_PLAYER = "2";
        private const string INVALID_OPTION = "3";

        Mock<ITicTacToe>  ticTacToe;
        Mock<TicTacToeBoardDrawer> ticTacToeBoardDrawer;
        Mock<ConsoleIO> consoleIO;
        TicTacToeConsoleRunner tttConsoleRunner;
        AskingForPlayerState asking4PlayerState;

        [SetUp]
        public void TestSetUp()
        {
            ticTacToe = new Mock<ITicTacToe>();
            ticTacToeBoardDrawer = new Mock<TicTacToeBoardDrawer>();
            consoleIO = new Mock<ConsoleIO>();
            tttConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, ticTacToeBoardDrawer.Object, consoleIO.Object);

            asking4PlayerState = new AskingForPlayerState(tttConsoleRunner);
            tttConsoleRunner.State = asking4PlayerState;
        }

        [Test]
        public void IfUserChoosesAI_NextStateIsPlaying()
        {
            asking4PlayerState.Evaluate(AI_PLAYER);

            tttConsoleRunner.State.Should().BeOfType(typeof(PlayingState));
        }

        [Test]
        public void IfUserChoosesAI_TicTacToeSetInitialPlayerIsCalledWitCellTypeAI()
        {
            asking4PlayerState.Evaluate(AI_PLAYER);

            ticTacToe.Verify(ttt => ttt.SetInitialPlayer(CellType.AI), Times.Once());
        }

        [Test]
        public void IfUserChoosesOpponent_TicTacToeSetInitialPlayerIsCalledWitCellTypeOpponent()
        {
            asking4PlayerState.Evaluate(HUMAN_PLAYER);

            ticTacToe.Verify(ttt => ttt.SetInitialPlayer(CellType.Opponent), Times.Once());
        }

        [Test]
        public void IfUserChoosesNorOpponentNeitherAI_StateRemainsAskingForPlayer()
        {
            asking4PlayerState.Evaluate(INVALID_OPTION);

            tttConsoleRunner.State.Should().BeOfType(typeof(AskingForPlayerState));
        }
    }
}