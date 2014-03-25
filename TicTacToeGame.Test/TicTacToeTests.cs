using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace TicTacToeGame.Test
{
    [TestClass]
    public class TicTacToeTests
    {
        [TestMethod]
        public void GivenANewGame_TheAIPutTheMarkInTheCenter()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe.AIMove();

            var expectedBoard = new Cell[3,3]{{Cell.Empty, Cell.Empty, Cell.Empty},
                                                {Cell.Empty, Cell.AI, Cell.Empty},
                                                {Cell.Empty, Cell.Empty, Cell.Empty}};

            ticTacToe.Board.Should().BeEquivalentTo(expectedBoard);
        }
    }
}
