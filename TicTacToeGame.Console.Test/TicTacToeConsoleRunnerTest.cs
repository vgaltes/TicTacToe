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
            consoleIO.SetupSequence(c => c.ReadLine()).Returns("1");

            ticTacToeConsoleRunner.Run();

            ticTacToe.Verify(ttt => ttt.SetInitialPlayer(CellType.AI));
        }

        [Test]
        public void WhenRunningGame_DrawEmptyBoardAtStart()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns("1");

            ticTacToeConsoleRunner.Run();

            ticTacToeBoardDrawer.Verify(tbd => tbd.GetRepresentationOf(It.IsAny<Board>()));
        }
    }
}
