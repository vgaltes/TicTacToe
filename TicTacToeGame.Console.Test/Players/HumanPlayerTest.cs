using NUnit.Framework;
using Moq;
using TicTacToeGame.Console.Players;
using FluentAssertions;

namespace TicTacToeGame.Console.Test.Players
{
    [TestFixture]
    public class HumanPlayerTest
    {
        [Test]
        public void WhenAskingForUserInput_ReadCoordinatesFromConsole()
        {
            var consoleIO = new Mock<ConsoleIO>();
            var humanPlayer = new HumanPlayer(consoleIO.Object);
            var expectedUserInput = "userInput";

            consoleIO.Setup(c => c.ReadLine()).Returns(expectedUserInput);

            var userInput = humanPlayer.AskForUserInput();

            consoleIO.Verify(c => c.ReadLine(), Times.Once());
            userInput.Should().Be(expectedUserInput);
        }
    }
}
