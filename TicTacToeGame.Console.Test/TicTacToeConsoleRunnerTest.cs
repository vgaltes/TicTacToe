using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using TicTacToeGame.Console;

namespace TicTacToeGame.Console.Test
{
    [TestFixture]
    public class TicTacToeConsoleRunnerTest
    {
        [Test]
        public void WhenRunningGame_AsksForPlayer()
        {
            var ticTacToe = new Mock<ITicTacToe>();
            var ticTacToeBoardDrawer = new Mock<TicTacToeBoardDrawer>();
            var consoleIO = new Mock<ConsoleIO>();

            var ticTacToeConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, ticTacToeBoardDrawer.Object, consoleIO.Object);

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.SelectPlayer));
        }
    }
}
