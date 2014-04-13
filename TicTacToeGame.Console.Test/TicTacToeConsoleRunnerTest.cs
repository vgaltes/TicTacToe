using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using TicTacToeGame.Console;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.Test
{
    [TestFixture]
    public class TicTacToeConsoleRunnerTest
    {
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

            ticTacToeConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, ticTacToeBoardDrawer.Object, consoleIO.Object);
        }

        [Test]
        public void WhenRunningGame_AsksForPlayer()
        {
            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.SelectPlayer));
        }

        [Test]
        public void WhenRunningGame_IfThePlayerIsNotValid_AsksOneMoreTime()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns("3").Returns("2");

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.SelectPlayer), Times.Exactly(2));
        }

        [Test]
        public void WhenRunningGame_IfThePlayerIsAI_CallTicTacToeWithCellTypeAI()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns("1");

            ticTacToeConsoleRunner.Run();

            ticTacToe.Verify(ttt => ttt.SetInitialPlayer(CellType.AI));
        }

        [Test]
        public void WhenRunningGame_DrawEmptyBoardAtStart()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns("1");
            var boardRepresentation = "board representation";
            ticTacToeBoardDrawer.Setup(tbd => tbd.GetRepresentationOf(It.IsAny<Board>())).Returns(boardRepresentation);

            ticTacToeConsoleRunner.Run();

            ticTacToeBoardDrawer.Verify(tbd => tbd.GetRepresentationOf(It.IsAny<Board>()));
            consoleIO.Verify(c => c.WriteLine(boardRepresentation));
        }

        [Test]
        public void WhenRunningGame_IfTheStateIsAIWinsWriteIt()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns("1");
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.AIWins);

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.AiWins));
        }

        [Test]
        public void WhenRunningGame_IfTheStateIsOpponentWinsWriteIt()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns("1");
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.OpponentWins);

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.YouWin));
        }

        [Test]
        public void WhenRunningGame_IfTheStateIsDrawWriteIt()
        {
            consoleIO.Setup(c => c.ReadLine()).Returns("1");
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.Draw);

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.Draw));
        }

        [Test]
        public void WhenRunningGame_IfTheUserWritesTheQuitCommandTheGameEnds()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns("1").Returns("q!");

            ticTacToeConsoleRunner.Run();

            ticTacToeBoardDrawer.Verify(tbd => tbd.GetRepresentationOf(It.IsAny<Board>()), Times.Once());
        }

        [Test]
        public void WhenRunningGame_ReadInputUntilValidCoordinate()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns("1").Returns("a,a").Returns("").Returns("1,1");

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.ReadLine(), Times.AtLeast(4));
        }
    }
}
