﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using TicTacToeGame.Console;
using TicTacToeGame.Models;
using TicTacToeGame.Exceptions;

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

            ticTacToe.SetupGet(ttt => ttt.Board).Returns(new Board());
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.Playing);

            ticTacToeConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, ticTacToeBoardDrawer.Object, consoleIO.Object);
        }

        [Test]
        public void WhenRunningGame_AsksForPlayer()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns("2").Returns("q!");
            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.SelectPlayer));
        }

        [Test]
        public void WhenRunningGame_IfThePlayerIsNotValid_AsksOneMoreTime()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns("3").Returns("2").Returns("q!");

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.SelectPlayer), Times.Exactly(2));
        }

        [Test]
        public void WhenRunningGame_IfThePlayerIsAI_CallTicTacToeWithCellTypeAI()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns("1").Returns("q!");

            ticTacToeConsoleRunner.Run();

            ticTacToe.Verify(ttt => ttt.SetInitialPlayer(CellType.AI));
        }

        [Test]
        public void WhenRunningGame_DrawEmptyBoardAtStart()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns("1").Returns("q!");
            var boardRepresentation = "board representation";
            ticTacToeBoardDrawer.Setup(tbd => tbd.GetRepresentationOf(It.IsAny<Board>())).Returns(boardRepresentation);

            ticTacToeConsoleRunner.Run();

            ticTacToeBoardDrawer.Verify(tbd => tbd.GetRepresentationOf(It.IsAny<Board>()));
            consoleIO.Verify(c => c.WriteLine(boardRepresentation));
        }

        [Test]
        public void WhenRunningGame_IfTheStateIsAIWinsWriteIt()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns("1").Returns("q!");
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.AIWins);

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.AiWins));
        }

        [Test]
        public void WhenRunningGame_IfTheStateIsOpponentWinsWriteIt()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns("1").Returns("q!");
            ticTacToe.SetupGet(ttt => ttt.State).Returns(TicTacToeState.OpponentWins);

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.YouWin));
        }

        [Test]
        public void WhenRunningGame_IfTheStateIsDrawWriteIt()
        {
            consoleIO.SetupSequence(c => c.ReadLine()).Returns("1").Returns("q!");
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
            consoleIO.SetupSequence(c => c.ReadLine()).Returns("1").Returns("a,a").Returns("").Returns("1,1").Returns("q!");
            
            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.ReadLine(), Times.AtLeast(4));
        }

        [Test]
        public void WhenRunningGame_WhileTheStateIsPlaying_PlayOpponentWithTheCoordinates()
        {
            var firstOpponentMove = new CellCoordinates(1,1);
            var secondOpponentMove = new CellCoordinates(1, 2);
            consoleIO.SetupSequence(c => c.ReadLine())
                .Returns("1")
                .Returns(string.Format("{0},{1}", firstOpponentMove.Row, firstOpponentMove.Column))
                .Returns(string.Format("{0},{1}", secondOpponentMove.Row, secondOpponentMove.Column))
                .Returns("q!");

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
                return line.Contains(Resources.MovementNotAllowed);
            return false;
        }

        [Test]
        public void WhenRunningAGame_IfAfterPlayingTheStateIsNotPlaying_ReadKey()
        {
            ticTacToe.SetupGet(ttt => ttt.State)
                .Returns(TicTacToeState.Draw);

            SetupOneMovementAndQuit();

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.ReadKey(), Times.Once());
        }

        [Test]
        public void WhenRunningAGame_IfAfterPlayingTheStateIsNotPlaying_ResetTicTacToe()
        {
            ticTacToe.SetupGet(ttt => ttt.State)
                .Returns(TicTacToeState.Draw);

            SetupOneMovementAndQuit();

            ticTacToeConsoleRunner.Run();

            ticTacToe.Verify(ttt => ttt.Reset());
        }

        [Test]
        public void WhenRunningAGame_IfAfterPlayingTheStateIsNotPlaying_AsksForPlayer()
        {
            ticTacToe.SetupGet(ttt => ttt.State)
                .Returns(TicTacToeState.Draw);

            var opponentMove = new CellCoordinates(1, 1);
            consoleIO.SetupSequence(c => c.ReadLine())
                .Returns("1")
                .Returns(string.Format("{0},{1}", opponentMove.Row, opponentMove.Column))
                .Returns("1")
                .Returns("q!");

            ticTacToeConsoleRunner.Run();

            consoleIO.Verify(c => c.WriteLine(Resources.SelectPlayer), Times.Exactly(2));
        }

        private void SetupOneMovementAndQuit()
        {
            var opponentMove = new CellCoordinates(1, 1);
            consoleIO.SetupSequence(c => c.ReadLine())
                .Returns("1")
                .Returns(string.Format("{0},{1}", opponentMove.Row, opponentMove.Column))
                .Returns("q!");
        }
    }
}
