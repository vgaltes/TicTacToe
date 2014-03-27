using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace TicTacToeGame.Console.Test
{
    [TestClass]
    public class TicTacToeBoardDrawerTests
    {
        [TestMethod]
        public void GetBoardRepresentationOfAnEmptyBoard_ReturnsEmptyBoardDrawnAsAString()
        {
            Cell[,] board = new Cell[3, 3]{{Cell.Empty, Cell.Empty, Cell.Empty},
                                                {Cell.Empty, Cell.Empty, Cell.Empty},
                                                {Cell.Empty, Cell.Empty, Cell.Empty}};

            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();
            var boardRepresentation = ticTacToeBoardDrawer.GetRepresentationOf(board);

            var expectedRepresentation = " | | \n-----\n | | \n-----\n | | ";

            boardRepresentation.Should().Be(expectedRepresentation);
        }
    }
}
