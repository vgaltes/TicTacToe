using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.Test
{
    [TestFixture]
    public class TicTacToeBoardDrawerTests
    {
        [Test]
        public void GetBoardRepresentationOfAnEmptyBoard_ReturnsEmptyBoardDrawnAsAString()
        {
            Board board = new Board();

            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();
            var boardRepresentation = ticTacToeBoardDrawer.GetRepresentationOf(board);

            var expectedRepresentation = " | | \n-----\n | | \n-----\n | | ";

            boardRepresentation.Should().Be(expectedRepresentation);
        }

        [Test]
        public void GetBoardRepresentationOfBoardWithAIInSomeCells_ReturnsTheBoardDrawnAsAString()
        {
            Board board = new Board();
            board.FillAICell(new MarkCoordinate(0, 0));
            board.FillAICell(new MarkCoordinate(1, 1));
            board.FillAICell(new MarkCoordinate(2, 2));

            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();
            var boardRepresentation = ticTacToeBoardDrawer.GetRepresentationOf(board);

            var expectedRepresentation = "X| | \n-----\n |X| \n-----\n | |X";

            boardRepresentation.Should().Be(expectedRepresentation);
        }

        [Test]
        public void GetBoardRepresentationOfBoardWithOpponentInSomeCells_ReturnsTheBoardDrawnAsAString()
        {
            Board board = new Board();
            board.FillOpponentCell(new MarkCoordinate(0, 1));
            board.FillOpponentCell(new MarkCoordinate(0, 2));
            board.FillOpponentCell(new MarkCoordinate(1, 0));
            board.FillOpponentCell(new MarkCoordinate(1, 2));
            board.FillOpponentCell(new MarkCoordinate(2, 0));
            board.FillOpponentCell(new MarkCoordinate(2, 1));
            

            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();
            var boardRepresentation = ticTacToeBoardDrawer.GetRepresentationOf(board);

            var expectedRepresentation = " |O|O\n-----\nO| |O\n-----\nO|O| ";

            boardRepresentation.Should().Be(expectedRepresentation);
        }
    }
}