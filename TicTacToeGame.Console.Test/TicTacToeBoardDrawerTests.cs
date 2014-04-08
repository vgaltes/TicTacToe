using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace TicTacToeGame.Console.Test
{
    [TestFixture]
    public class TicTacToeBoardDrawerTests
    {
        [Test]
        public void GetBoardRepresentationOfAnEmptyBoard_ReturnsEmptyBoardDrawnAsAString()
        {
            //Cell[,] board = new Cell[3, 3]{{Cell.Empty, Cell.Empty, Cell.Empty},
            //                                    {Cell.Empty, Cell.Empty, Cell.Empty},
            //                                    {Cell.Empty, Cell.Empty, Cell.Empty}};

            Board board = new Board();

            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();
            var boardRepresentation = ticTacToeBoardDrawer.GetRepresentationOf(board);

            var expectedRepresentation = " | | \n-----\n | | \n-----\n | | ";

            boardRepresentation.Should().Be(expectedRepresentation);
        }

        [Test]
        public void GetBoardRepresentationOfBoardWithAIInSomeCells_ReturnsTheBoardDrawnAsAString()
        {
            //Cell[,] board = new Cell[3, 3]{{Cell.AI, Cell.Empty, Cell.Empty},
            //                                    {Cell.Empty, Cell.AI, Cell.Empty},
            //                                    {Cell.Empty, Cell.Empty, Cell.AI}};

            Board board = new Board();
            board.FillAICell(0, 0);
            board.FillAICell(1, 1);
            board.FillAICell(2, 2);

            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();
            var boardRepresentation = ticTacToeBoardDrawer.GetRepresentationOf(board);

            var expectedRepresentation = "X| | \n-----\n |X| \n-----\n | |X";

            boardRepresentation.Should().Be(expectedRepresentation);
        }

        [Test]
        public void GetBoardRepresentationOfBoardWithOpponentInSomeCells_ReturnsTheBoardDrawnAsAString()
        {
            //Cell[,] board = new Cell[3, 3]{{Cell.Empty, Cell.Opponent, Cell.Opponent},
            //                                    {Cell.Opponent, Cell.Empty, Cell.Opponent},
            //                                    {Cell.Opponent, Cell.Opponent, Cell.Empty}};

            Board board = new Board();
            board.FillOpponentCell(0, 1);
            board.FillOpponentCell(0, 2);
            board.FillOpponentCell(1, 0);
            board.FillOpponentCell(1, 2);
            board.FillOpponentCell(2, 0);
            board.FillOpponentCell(2, 1);
            

            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();
            var boardRepresentation = ticTacToeBoardDrawer.GetRepresentationOf(board);

            var expectedRepresentation = " |O|O\n-----\nO| |O\n-----\nO|O| ";

            boardRepresentation.Should().Be(expectedRepresentation);
        }
    }
}