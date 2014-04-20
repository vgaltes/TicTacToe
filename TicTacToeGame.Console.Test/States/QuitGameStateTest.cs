using Moq;
using NUnit.Framework;
using TicTacToeGame.Console.States;
using FluentAssertions;

namespace TicTacToeGame.Console.Test.States
{
    [TestFixture]
    public class QuitGameStateTest
    {
        [Test]
        public void WhenEvaluating_SetIsFinishedToTrue()
        {
            var ticTacToe = new Mock<ITicTacToe>();
            var ticTacToeBoardDrawer = new Mock<TicTacToeBoardDrawer>();
            var consoleIO = new Mock<ConsoleIO>();
            var tttConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, ticTacToeBoardDrawer.Object, consoleIO.Object);
            
            var quitGameState = new QuitGameState(tttConsoleRunner);
            tttConsoleRunner.State = quitGameState;

            quitGameState.Evaluate();

            tttConsoleRunner.State.IsFinished.Should().BeTrue();
        }
    }
}
