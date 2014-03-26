using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using TicTacToeGame;

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

        [TestMethod]
        public void GivenThereIsAnOpponentMarkInTheCenter_TheAIPutTheMarkInTheFirstCorner()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe.OpponentMove(1, 1);
            ticTacToe.AIMove();

            var expectedBoard = new Cell[3, 3]{{Cell.AI, Cell.Empty, Cell.Empty},
                                                {Cell.Empty, Cell.Opponent, Cell.Empty},
                                                {Cell.Empty, Cell.Empty, Cell.Empty}};

            ticTacToe.Board.Should().BeEquivalentTo(expectedBoard);
        }

        [TestMethod]
        public void GivenThereIsAnOpponentInTheFirstCorner_TheAIPutsTheMarkInTheThirdCorner()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe.OpponentMove(0, 0);
            ticTacToe.AIMove();

            var expectedBoard = new Cell[3, 3]{{Cell.Opponent, Cell.Empty, Cell.Empty},
                                                {Cell.Empty, Cell.Empty, Cell.Empty},
                                                {Cell.Empty, Cell.Empty, Cell.AI}};

            ticTacToe.Board.Should().BeEquivalentTo(expectedBoard);
        }

        [TestMethod]
        public void GivenThereIsAnOpponentInTheSecondCorner_TheAIPutsTheMarkInTheFourthCorner()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe.OpponentMove(0, 2);
            ticTacToe.AIMove();

            var expectedBoard = new Cell[3, 3]{{Cell.Empty, Cell.Empty, Cell.Opponent},
                                                {Cell.Empty, Cell.Empty, Cell.Empty},
                                                {Cell.AI, Cell.Empty, Cell.Empty}};

            ticTacToe.Board.Should().BeEquivalentTo(expectedBoard);
        }
    }
}
