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
        private const char AI_CELL = 'X';
        private const char OPPONENT_CELL = 'O';

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
            board.FillCell(new CellCoordinates(0, 0), AI_CELL);
            board.FillCell(new CellCoordinates(1, 1), AI_CELL);
            board.FillCell(new CellCoordinates(2, 2), AI_CELL);

            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();
            var boardRepresentation = ticTacToeBoardDrawer.GetRepresentationOf(board);

            var expectedRepresentation = "X| | \n-----\n |X| \n-----\n | |X";

            boardRepresentation.Should().Be(expectedRepresentation);
        }

        [Test]
        public void GetBoardRepresentationOfBoardWithOpponentInSomeCells_ReturnsTheBoardDrawnAsAString()
        {
            Board board = new Board();
            board.FillCell(new CellCoordinates(0, 1), OPPONENT_CELL);
            board.FillCell(new CellCoordinates(0, 2), OPPONENT_CELL);
            board.FillCell(new CellCoordinates(1, 0), OPPONENT_CELL);
            board.FillCell(new CellCoordinates(1, 2), OPPONENT_CELL);
            board.FillCell(new CellCoordinates(2, 0), OPPONENT_CELL);
            board.FillCell(new CellCoordinates(2, 1), OPPONENT_CELL);
            

            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();
            var boardRepresentation = ticTacToeBoardDrawer.GetRepresentationOf(board);

            var expectedRepresentation = " |O|O\n-----\nO| |O\n-----\nO|O| ";

            boardRepresentation.Should().Be(expectedRepresentation);
        }
    }
}