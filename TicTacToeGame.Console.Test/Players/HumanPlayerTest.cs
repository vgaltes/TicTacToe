using NUnit.Framework;
using Moq;
using TicTacToeGame.Console.Players;
using FluentAssertions;
using TicTacToeGame.Models;
using TicTacToeGame.Exceptions;

namespace TicTacToeGame.Console.Test.Players
{
    [TestFixture]
    public class HumanPlayerTest
    {
        private const string VALID_COORDINATES_AS_STRING = "1,1";
        private const string OUT_OF_BOUNDS_COORDINATES = "5,5";
        private const string NEGATIVE_COORDINATES = "-1,-1";
        private string BEYOND_MAX_INT_COORDINATES = "2147483648, 2147483648";
        private const string NON_NUMERIC_COORDINATES = "a,a";
        private CellCoordinates VALID_COORDINATES = new CellCoordinates(1, 1);
        private const char mark = 'X';

        Mock<ConsoleIO> consoleIO;
        Mock<Board> board;
        HumanPlayer humanPlayer;        

        [SetUp]
        public void TestSetUp()
        {
            consoleIO = new Mock<ConsoleIO>();
            board = new Mock<Board>();
            humanPlayer = new HumanPlayer(consoleIO.Object, mark);
        }

        [Test]
        public void WhenAskingForUserInput_ReadCoordinatesFromConsole()
        {
            var expectedUserInput = "userInput";

            consoleIO.Setup(c => c.ReadLine()).Returns(expectedUserInput);

            var userInput = humanPlayer.AskForUserInput();

            consoleIO.Verify(c => c.WriteLine(Resources.WriteCoordinates), Times.Once());
            consoleIO.Verify(c => c.ReadLine(), Times.Once());
            userInput.Should().Be(expectedUserInput);
        }

        [Test]
        public void GivenAValidCoordinates_CallMove()
        {
            humanPlayer.Move(board.Object, VALID_COORDINATES_AS_STRING);

            board.Verify(b => b.FillCell(VALID_COORDINATES, mark));
            
        }

        [Test, ExpectedException(ExpectedException=typeof(NotAllowedMovementException))]
        public void GivenUserWritesCoordinatesOutOfTheBounds_ThrowNotAllowedMovementException()
        {
            humanPlayer.Move(board.Object, OUT_OF_BOUNDS_COORDINATES);
        }

        [Test, ExpectedException(ExpectedException = typeof(NotAllowedMovementException))]
        public void GivenUserWritesNegativeCoordinates_ThrowNotAllowedMovementException()
        {
            humanPlayer.Move(board.Object, NEGATIVE_COORDINATES);
        }

        [Test, ExpectedException(ExpectedException = typeof(NotAllowedMovementException))]
        public void GivenUserWritesCoordinatesBeyondMaxInt_ThrowNotAllowedMovementException()
        {
            humanPlayer.Move(board.Object, BEYOND_MAX_INT_COORDINATES);
        }

        [Test, ExpectedException(ExpectedException = typeof(NotAllowedMovementException))]
        public void GivenUserWritesNonNumericCoordinates_ThrowNotAllowedMovementException()
        {
            humanPlayer.Move(board.Object, NON_NUMERIC_COORDINATES);
        }
    }
}