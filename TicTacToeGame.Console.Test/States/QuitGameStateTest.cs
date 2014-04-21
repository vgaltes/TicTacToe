using Moq;
using NUnit.Framework;
using TicTacToeGame.Console.States;
using FluentAssertions;
using TicTacToeGame.Console.Players;

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
            var player1 = new Mock<Player>();
            var player2 = new Mock<Player>();

            var tttConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, 
                ticTacToeBoardDrawer.Object, consoleIO.Object, player1.Object, player2.Object);
            
            var quitGameState = new QuitGameState(tttConsoleRunner);
            tttConsoleRunner.State = quitGameState;

            quitGameState.Evaluate();

            tttConsoleRunner.State.IsFinished.Should().BeTrue();
        }
    }
}
