using NUnit.Framework;
using Moq;
using TicTacToeGame.Console.Players;
using FluentAssertions;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.Test.Players
{
    [TestFixture]
    public class HumanPlayerTest
    {
        Mock<ConsoleIO> consoleIO;
        Mock<ITicTacToe> ticTacToe;
        HumanPlayer humanPlayer;
        private const string VALID_COORDINATES_AS_STRING = "1,1";
        private CellCoordinates VALID_COORDINATES = new CellCoordinates(1, 1);

        [SetUp]
        public void TestSetUp()
        {
            consoleIO = new Mock<ConsoleIO>();
            ticTacToe = new Mock<ITicTacToe>();
            humanPlayer = new HumanPlayer(consoleIO.Object, ticTacToe.Object);
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
            humanPlayer.Move(VALID_COORDINATES_AS_STRING);

            ticTacToe.Verify(ttt => ttt.HumanMove(VALID_COORDINATES), Times.Once());
        }
    }
}