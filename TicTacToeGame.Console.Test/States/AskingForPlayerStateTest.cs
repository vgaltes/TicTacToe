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

        [Test]
        public void IfUserChoosesAI_NextStateIsPlaying()
        {
            var ticTacToe = new Mock<ITicTacToe>();
            var ticTacToeBoardDrawer = new Mock<TicTacToeBoardDrawer>();
            var consoleIO = new Mock<ConsoleIO>();
            var tttConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, ticTacToeBoardDrawer.Object, consoleIO.Object);
            
            var asking4PlayerState = new AskingForPlayerState(tttConsoleRunner);

            consoleIO.Setup(c => c.ReadLine()).Returns(AI_PLAYER);

            asking4PlayerState.Run();

            tttConsoleRunner.State.Should().BeOfType(typeof(PlayingState));
        }

        [Test]
        public void IfUserChoosesAI_TicTacToeSetInitialPlayerIsCalledWitCellTypeAI()
        {
            var ticTacToe = new Mock<ITicTacToe>();
            var ticTacToeBoardDrawer = new Mock<TicTacToeBoardDrawer>();
            var consoleIO = new Mock<ConsoleIO>();
            var tttConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, ticTacToeBoardDrawer.Object, consoleIO.Object);

            var asking4PlayerState = new AskingForPlayerState(tttConsoleRunner);

            consoleIO.Setup(c => c.ReadLine()).Returns(AI_PLAYER);

            asking4PlayerState.Run();

            ticTacToe.Verify(ttt => ttt.SetInitialPlayer(CellType.AI), Times.Once());
        }
    }
}