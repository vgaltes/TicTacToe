using Moq;
using NUnit.Framework;
using TicTacToeGame.Console.States;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.Test.States
{
    [TestFixture]
    public class PlayingStateTest
    {
        private const string VALID_COORDINATES_AS_STRING = "1,1";
        private const string ANOTHER_VALID_COORDINATES_AS_STRING = "2,2";
        private CellCoordinates VALID_COORDINATES = new CellCoordinates(1, 1);
        private CellCoordinates ANOTHER_VALID_COORDINATES = new CellCoordinates(2, 2);

        Mock<ITicTacToe> ticTacToe;
        Mock<TicTacToeBoardDrawer> ticTacToeBoardDrawer;
        Mock<ConsoleIO> consoleIO;
        TicTacToeConsoleRunner tttConsoleRunner;
        PlayingState playingState;

        [SetUp]
        public void TestSetUp()
        {
            ticTacToe = new Mock<ITicTacToe>();
            ticTacToeBoardDrawer = new Mock<TicTacToeBoardDrawer>();
            consoleIO = new Mock<ConsoleIO>();
            tttConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, ticTacToeBoardDrawer.Object, consoleIO.Object);

            playingState = new PlayingState(tttConsoleRunner);
            tttConsoleRunner.State = playingState;
        }

        [Test]
        public void AskForCoordinates()
        {
            playingState.Evaluate();

            consoleIO.Verify(c => c.WriteLine(Resources.WriteCoordinates));
        }

        [Test]
        public void ReadCoordinates()
        {
            playingState.Evaluate();

            consoleIO.Verify(c => c.ReadLine(), Times.Once());
        }

        [Test]
        public void GivenAValidCoordinates_CallOpponentMove()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(VALID_COORDINATES_AS_STRING);

            playingState.Evaluate();

            ticTacToe.Verify(ttt => ttt.OpponentMove(VALID_COORDINATES), Times.Once());
        }

        [Test]
        public void GivenAValidCoordinates_CallOpponentMoveWithTheCoordinatesTransaltedFromUserInput()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(ANOTHER_VALID_COORDINATES_AS_STRING);

            playingState.Evaluate();

            ticTacToe.Verify(ttt => ttt.OpponentMove(ANOTHER_VALID_COORDINATES), Times.Once());
        }
    }
}
