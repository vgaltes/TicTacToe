using Moq;
using NUnit.Framework;
using TicTacToeGame.Console.States;
using TicTacToeGame.Models;
using FluentAssertions;
using TicTacToeGame.Console.Players;

namespace TicTacToeGame.Console.Test.States
{
    [TestFixture]
    public class PlayingStateTest
    {
        private const string VALID_COORDINATES_AS_STRING = "1,1";
        private const string ANOTHER_VALID_COORDINATES_AS_STRING = "2,2";
        private const string NEGATIVE_COORDINATES = "-1,-1";
        private string BEYOND_MAX_INT_COORDINATES = "2147483648, 2147483648";
        private const string QUIT_COMMAND = "q!";
        private CellCoordinates VALID_COORDINATES = new CellCoordinates(1, 1);
        private CellCoordinates ANOTHER_VALID_COORDINATES = new CellCoordinates(2, 2);
        private const string OUT_OF_BOUNDS_COORDINATES = "5,5";
        private const string NON_NUMERIC_COORDINATES = "a,a";
        private const string BOARD_REPRESENTATION = "boardRepresentation";

        Mock<ITicTacToe> ticTacToe;
        Mock<TicTacToeBoardDrawer> ticTacToeBoardDrawer;
        Mock<ConsoleIO> consoleIO;
        Mock<Player> player1;
        Mock<Player> player2;
        TicTacToeConsoleRunner tttConsoleRunner;
        PlayingState playingState;

        [SetUp]
        public void TestSetUp()
        {
            ticTacToe = new Mock<ITicTacToe>();
            ticTacToe.SetupGet(ttt => ttt.Board).Returns(new Board());
            ticTacToeBoardDrawer = new Mock<TicTacToeBoardDrawer>();
            consoleIO = new Mock<ConsoleIO>();
            player1 = new Mock<Player>();
            player2 = new Mock<Player>();
            player1 = new Mock<Player>();
            player2 = new Mock<Player>();

            tttConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, 
                ticTacToeBoardDrawer.Object, consoleIO.Object, player1.Object, player2.Object);
            
            playingState = new PlayingState(tttConsoleRunner);
            tttConsoleRunner.State = playingState;
        }

        [Test]
        public void WhenMovingForTheFirstTime_CallPlayer1Move()
        {
            player1.Setup(p => p.AskForUserInput()).Returns(VALID_COORDINATES_AS_STRING);
            playingState.Evaluate();

            player1.Verify(p => p.Move(VALID_COORDINATES_AS_STRING));
        }

        [Test]
        public void WhenMovingForTheFirstTime_CallPlayer1AskForUserInput()
        {
            playingState.Evaluate();

            player1.Verify(p => p.AskForUserInput());
        }

        [Test]
        public void AskForCoordinates()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(VALID_COORDINATES_AS_STRING);
            playingState.Evaluate();

            consoleIO.Verify(c => c.WriteLine(Resources.WriteCoordinates));
        }

        /*
        [Test]
        public void ReadCoordinates()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(VALID_COORDINATES_AS_STRING);
            playingState.Evaluate();

            consoleIO.Verify(c => c.ReadLine(), Times.Once());
        }

        [Test]
        public void GivenAValidCoordinates_CallOpponentMove()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(VALID_COORDINATES_AS_STRING);

            playingState.Evaluate();

            ticTacToe.Verify(ttt => ttt.HumanMove(VALID_COORDINATES), Times.Once());
        }

        [Test]
        public void GivenAValidCoordinates_CallOpponentMoveWithTheCoordinatesTransaltedFromUserInput()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(ANOTHER_VALID_COORDINATES_AS_STRING);

            playingState.Evaluate();

            ticTacToe.Verify(ttt => ttt.HumanMove(ANOTHER_VALID_COORDINATES), Times.Once());
        }*/

        [Test]
        public void GivenUserWritesQuit_StateIsQuitGameState()
        {
            player1.Setup(p => p.AskForUserInput()).Returns(QUIT_COMMAND);

            playingState.Evaluate();

            tttConsoleRunner.State.Should().BeOfType<QuitGameState>();
        }

        /*
        [Test]
        public void GivenUserWritesCoordinatesOutOfTheBounds_ExtraInfoIsSettedWithTheError()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(OUT_OF_BOUNDS_COORDINATES);

            playingState.Evaluate();

            tttConsoleRunner.State.InfoFromPreviousStep.Should().Be(Resources.NotAllowedMovement);
        }

        [Test]
        public void GivenUserWritesNegativeCoordinates_ExtraInfoIsSettedWithTheError()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(NEGATIVE_COORDINATES);

            playingState.Evaluate();

            tttConsoleRunner.State.InfoFromPreviousStep.Should().Be(Resources.NotAllowedMovement);
        }

        [Test]
        public void GivenUserWritesCoordinatesBeyondMaxInt_ExtraInfoIsSettedWithTheError()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(BEYOND_MAX_INT_COORDINATES);

            playingState.Evaluate();

            tttConsoleRunner.State.InfoFromPreviousStep.Should().Be(Resources.NotAllowedMovement);
        }

        [Test]
        public void GivenUserWritesNonNumericCoordinates_ExtraInfoIsSettedWithTheError()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(NON_NUMERIC_COORDINATES);

            playingState.Evaluate();

            tttConsoleRunner.State.InfoFromPreviousStep.Should().Be(Resources.NotAllowedMovement);
        }*/

        [Test]
        public void DrawBoard()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(VALID_COORDINATES_AS_STRING);
            ticTacToeBoardDrawer.Setup(bd => bd.GetRepresentationOf(It.IsAny<Board>())).Returns(BOARD_REPRESENTATION);

            playingState.Evaluate();

            ticTacToeBoardDrawer.Verify(bd => bd.GetRepresentationOf(It.IsAny<Board>()));
            consoleIO.Verify(c => c.WriteLine(BOARD_REPRESENTATION));
        }

        [Test]
        public void GivenTheStateAfterPlayingIsAIWins_TheNewStateIsAIWinsState()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(VALID_COORDINATES_AS_STRING);
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.AIWins);

            playingState.Evaluate();

            tttConsoleRunner.State.Should().BeOfType<AIWinsState>();
        }

        [Test]
        public void GivenTheStateAfterPlayingIsOpponentWins_TheNewStateIsHumanWinsState()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(VALID_COORDINATES_AS_STRING);
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.OpponentWins);

            playingState.Evaluate();

            tttConsoleRunner.State.Should().BeOfType<HumanWinsState>();
        }

        [Test]
        public void GivenTheStateAfterPlayingIsDraw_TheNewStateIsDrawState()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(VALID_COORDINATES_AS_STRING);
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.Draw);

            playingState.Evaluate();

            tttConsoleRunner.State.Should().BeOfType<DrawState>();
        }

        /*
        [Test]
        public void GivenTheStateAfterPlayingIsPlaying_CallAIMove()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns(VALID_COORDINATES_AS_STRING);
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.Playing);

            playingState.Evaluate();

            ticTacToe.Verify(ttt => ttt.AIMove(), Times.Once());
        }*/
    }
}