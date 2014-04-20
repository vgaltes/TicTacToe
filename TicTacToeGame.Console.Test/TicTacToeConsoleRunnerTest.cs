using Moq;
using NUnit.Framework;
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
        TicTacToeConsoleRunner ticTacToeConsoleRunner;

        [SetUp]
        public void TestSetUp()
        {
            ticTacToe = new Mock<ITicTacToe>();
            ticTacToeBoardDrawer = new Mock<TicTacToeBoardDrawer>();
            consoleIO = new Mock<ConsoleIO>();

            ticTacToe.SetupGet(ttt => ttt.Board).Returns(new Board());
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.Playing);

            ticTacToeConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, ticTacToeBoardDrawer.Object, consoleIO.Object);
        }

        [Test]
        public void WhenRunningGame_AsksForPlayer()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(HUMAN_PLAYER).Returns(QUIT_COMMAND);
            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.SelectPlayer));
        }

        [Test]
        public void WhenRunningGame_IfThePlayerIsNotValid_AsksOneMoreTime()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(INVALID_PLAYER).Returns(HUMAN_PLAYER).Returns(QUIT_COMMAND);

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.SelectPlayer), Times.Exactly(2));
        }

        [Test]
        public void WhenRunningGame_IfThePlayerIsAI_CallTicTacToeWithCellTypeAI()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(AI_PLAYER).Returns(QUIT_COMMAND);

            ticTacToeConsoleRunner.Run();

            ticTacToe.Verify(ttt => ttt.SetInitialPlayer(CellType.AI));
        }

        [Test]
        public void WhenRunningGame_DrawEmptyBoardAtStart()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(AI_PLAYER).Returns(QUIT_COMMAND);
            ticTacToeBoardDrawer.Setup(tbd => tbd.GetRepresentationOf(It.IsAny<Board>())).Returns(BOARD_REPRESENTATION);

            ticTacToeConsoleRunner.Run();

            ticTacToeBoardDrawer.Verify(tbd => tbd.GetRepresentationOf(It.IsAny<Board>()));
            consoleIO.Verify(c => c.WriteLine(BOARD_REPRESENTATION));
        }

        [Test]
        public void WhenRunningGame_IfTheStateIsAIWinsWriteIt()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(AI_PLAYER).Returns(QUIT_COMMAND);
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.AIWins);

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.AiWins));
        }

        [Test]
        public void WhenRunningGame_IfTheStateIsOpponentWinsWriteIt()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(AI_PLAYER).Returns(QUIT_COMMAND);
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.OpponentWins);

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.YouWin));
        }

        [Test]
        public void WhenRunningGame_IfTheStateIsDrawWriteIt()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(AI_PLAYER).Returns(QUIT_COMMAND);
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.Draw);

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.Draw));
        }

        [Test]
        public void WhenRunningGame_IfTheUserWritesTheQuitCommandTheGameEnds()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(AI_PLAYER).Returns(QUIT_COMMAND);

            ticTacToeConsoleRunner.Run();

            ticTacToeBoardDrawer.Verify(tbd => tbd.GetRepresentationOf(It.IsAny<Board>()), Times.Once());
        }

        [Test]
        public void WhenRunningGame_ReadInputUntilValidCoordinate()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(AI_PLAYER)
                .Returns(INVALID_COORDINATES).Returns(ANOTHER_INVALID_COORDINATES)
                .Returns(VALID_COORDINATES).Returns(QUIT_COMMAND);
            
            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.ReadLine(), Times.AtLeast(4));
        }

        [Test]
        public void WhenRunningGame_NegativeCoordinatesIsNotAValidCoordinate()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(AI_PLAYER)
                .Returns(NEGATIVE_COORDINATES).Returns(QUIT_COMMAND);

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.ReadLine(), Times.Exactly(3));
        }

        [Test]
        public void WhenRunningGame_HugeCoordinatesAreNotValidCoordinates()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns(AI_PLAYER)
                .Returns(HUGE_COORDINATES).Returns(QUIT_COMMAND);

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.ReadLine(), Times.Exactly(3));
        }

        [Test]
        public void WhenRunningGame_WhileTheStateIsPlaying_PlayOpponentWithTheCoordinates()
        {
            var firstOpponentMove = new CellCoordinates(1,1);
            var secondOpponentMove = new CellCoordinates(1, 2);
            consoleIO.SetupSequence(c => c.ReadLine())
                .Returns(AI_PLAYER)
                .Returns(string.Format("{0},{1}", firstOpponentMove.Row, firstOpponentMove.Column))
                .Returns(string.Format("{0},{1}", secondOpponentMove.Row, secondOpponentMove.Column))
                .Returns(QUIT_COMMAND);

            ticTacToeConsoleRunner.Run();

            ticTacToe.Verify(ttt => ttt.OpponentMove(firstOpponentMove));
            ticTacToe.Verify(ttt => ttt.OpponentMove(secondOpponentMove));
        }

        [Test]
        public void WhenRunningGame_DrawBoardAfterOpponentPlays()
        {
            SetupOneMovementAndQuit();

            ticTacToeConsoleRunner.Run();

            ticTacToeBoardDrawer.Verify(tbd => tbd.GetRepresentationOf(It.IsAny<Board>()), Times.Exactly(2));
        }

        [Test]
        public void WhenRunningGame_IfAMovementNotAllowedExceptionIsThrown_PrintIt()
        {
            SetupOneMovementAndQuit();
            ticTacToe.Setup(ttt => ttt.OpponentMove(It.IsAny<CellCoordinates>()))
                .Throws<NotAllowedMovementException>();

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(It.Is<string>( s => ValidateMovementNotAllowedWasWritten(s))));
        }

        private bool ValidateMovementNotAllowedWasWritten(string line)
        {
            if ( line != null)
                return line.Contains(Resources.NotAllowedMovement);
            return false;
        }

        [Test]
        public void WhenRunningAGame_IfAfterPlayingTheStateIsNotPlaying_ReadKey()
        {
            ticTacToe.SetupGet(ttt => ttt.State)
                .Returns(TicTacToeState.Draw);

            SetupOneMovementAndDraw();

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.ReadKey(), Times.Once());
        }

        [Test]
        public void WhenRunningAGame_IfAfterPlayingTheStateIsNotPlaying_ResetTicTacToe()
        {
            ticTacToe.SetupGet(ttt => ttt.State)
                .Returns(TicTacToeState.Draw);

            SetupOneMovementAndDraw();

            ticTacToeConsoleRunner.Run();

            ticTacToe.Verify(ttt => ttt.Reset());
        }

        [Test]
        public void WhenRunningAGame_IfAfterPlayingTheStateIsNotPlaying_DrawBoard()
        {
            ticTacToe.SetupGet(ttt => ttt.State)
                .Returns(TicTacToeState.Draw);

            SetupOneMovementAndDraw();

            ticTacToeConsoleRunner.Run();

            ticTacToeBoardDrawer.Verify(tbd => tbd.GetRepresentationOf(It.IsAny<Board>()), Times.Exactly(2));
        }

        private void SetupOneMovementAndDraw()
        {
            var opponentMove = new CellCoordinates(1, 1);
            consoleIO.SetupSequence(c => c.ReadLine())
                .Returns(AI_PLAYER)
                .Returns(string.Format("{0},{1}", opponentMove.Row, opponentMove.Column))
                .Returns(AI_PLAYER)
                .Returns(QUIT_COMMAND);
        }

        private void SetupOneMovementAndQuit()
        {
            var opponentMove = new CellCoordinates(1, 1);
            consoleIO.SetupSequence(c => c.ReadLine())
                .Returns(AI_PLAYER)
                .Returns(string.Format("{0},{1}", opponentMove.Row, opponentMove.Column))
                .Returns(QUIT_COMMAND);
        }
    }
}
