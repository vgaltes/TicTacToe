using Moq;
using NUnit.Framework;
using TicTacToeGame.Console.Players;

namespace TicTacToeGame.Console.Test.Players
{
    [TestFixture]
    public class AIPlayerTest
    {
        Mock<ConsoleIO> consoleIO;
        Mock<ITicTacToe> ticTacToe;
        AIPlayer aiPlayer;

        [SetUp]
        public void TestSetUp()
        {
            consoleIO = new Mock<ConsoleIO>();
            ticTacToe = new Mock<ITicTacToe>();
            ticTacToe.SetupGet(ttt => ttt.Board).Returns(new Board());
            aiPlayer = new AIPlayer(consoleIO.Object, ticTacToe.Object);
        }

        [Test]
        public void WritesAskForCoordinatesMessage()
        {
            aiPlayer.AskForUserInput();

            consoleIO.Verify(c => c.WriteLine(Resources.AIIsGonnaMove));
            consoleIO.Verify(c => c.ReadLine());
        }
    }
}