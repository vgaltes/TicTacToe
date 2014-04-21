using Moq;
using NUnit.Framework;
using TicTacToeGame.Console.Players;
using TicTacToeGame.Exceptions;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.Test
{
    [TestFixture]
    public class TicTacToeConsoleRunnerTest
    {
        private const string QUIT_COMMAND = "q!";
        private const string AI_PLAYER = "1";
        private const string HUMAN_PLAYER = "2";
        private const string INVALID_PLAYER = "3";
        private const string INVALID_COORDINATES = "a,a";
        private const string NEGATIVE_COORDINATES = "-1,-1";
        private const string ANOTHER_INVALID_COORDINATES = "";
        private const string VALID_COORDINATES = "1,1";
        private const string HUGE_COORDINATES = "2147483648,2147483648";
        private const string BOARD_REPRESENTATION = "board representation";

        Mock<ITicTacToe> ticTacToe;
        Mock<TicTacToeBoardDrawer> ticTacToeBoardDrawer;
        Mock<ConsoleIO> consoleIO;
        Mock<Player> player1;
        Mock<Player> player2;
        TicTacToeConsoleRunner ticTacToeConsoleRunner;

        [SetUp]
        public void TestSetUp()
        {
            ticTacToe = new Mock<ITicTacToe>();
            ticTacToeBoardDrawer = new Mock<TicTacToeBoardDrawer>();
            consoleIO = new Mock<ConsoleIO>();
            player1 = new Mock<Player>();
            player2 = new Mock<Player>();

            ticTacToe.SetupGet(ttt => ttt.Board).Returns(new Board());
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.Playing);

            ticTacToeConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, 
                ticTacToeBoardDrawer.Object, consoleIO.Object, player1.Object, player2.Object);
        }

        [Test]
        public void WhenRunningGame_AsksForPlayer()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(HUMAN_PLAYER);
            player1.Setup(p => p.AskForUserInput()).Returns(QUIT_COMMAND);
            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.SelectPlayer));
        }

        [Test]
        public void WhenRunningGame_IfThePlayerIsNotValid_AsksOneMoreTime()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(INVALID_PLAYER).Returns(HUMAN_PLAYER);
            player1.Setup(p => p.AskForUserInput()).Returns(QUIT_COMMAND);

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.SelectPlayer), Times.Exactly(2));
        }

        [Test]
        public void WhenRunningGame_DrawEmptyBoardAtStart()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(AI_PLAYER);
            player1.Setup(p => p.AskForUserInput()).Returns(QUIT_COMMAND);
            ticTacToeBoardDrawer.Setup(tbd => tbd.GetRepresentationOf(It.IsAny<Board>())).Returns(BOARD_REPRESENTATION);

            ticTacToeConsoleRunner.Run();

            ticTacToeBoardDrawer.Verify(tbd => tbd.GetRepresentationOf(It.IsAny<Board>()));
            consoleIO.Verify(c => c.WriteLine(BOARD_REPRESENTATION));
        }

        [Test]
        public void WhenRunningGame_IfTheUserWritesTheQuitCommandTheGameEnds()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(AI_PLAYER);
            player1.Setup(p => p.AskForUserInput()).Returns(QUIT_COMMAND);

            ticTacToeConsoleRunner.Run();

            ticTacToeBoardDrawer.Verify(tbd => tbd.GetRepresentationOf(It.IsAny<Board>()), Times.Once());
        }
    }
}