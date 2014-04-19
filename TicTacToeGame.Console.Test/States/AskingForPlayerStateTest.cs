﻿using Moq;
using NUnit.Framework;
using FluentAssertions;
using TicTacToeGame.Console.States;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.Test.States
{
    [TestFixture]
    public class AskingForPlayerStateTest
    {
        private const string AI_PLAYER = "1";
        private const string HUMAN_PLAYER = "2";

        Mock<ITicTacToe>  ticTacToe;
        Mock<TicTacToeBoardDrawer> ticTacToeBoardDrawer;
        Mock<ConsoleIO> consoleIO;
        TicTacToeConsoleRunner tttConsoleRunner;
        AskingForPlayerState asking4PlayerState;

        [SetUp]
        public void TestSetUp()
        {
            ticTacToe = new Mock<ITicTacToe>();
            ticTacToeBoardDrawer = new Mock<TicTacToeBoardDrawer>();
            consoleIO = new Mock<ConsoleIO>();
            tttConsoleRunner = new TicTacToeConsoleRunner(ticTacToe.Object, ticTacToeBoardDrawer.Object, consoleIO.Object);

            asking4PlayerState = new AskingForPlayerState(tttConsoleRunner);
        }

        [Test]
        public void IfUserChoosesAI_NextStateIsPlaying()
        {
            asking4PlayerState.Evaluate(AI_PLAYER);

            tttConsoleRunner.State.Should().BeOfType(typeof(PlayingState));
        }

        [Test]
        public void IfUserChoosesAI_TicTacToeSetInitialPlayerIsCalledWitCellTypeAI()
        {
            asking4PlayerState.Evaluate(AI_PLAYER);

            ticTacToe.Verify(ttt => ttt.SetInitialPlayer(CellType.AI), Times.Once());
        }

        [Test]
        public void IfUserChoosesOpponent_TicTacToeSetInitialPlayerIsCalledWitCellTypeOpponent()
        {
            var asking4PlayerState = new AskingForPlayerState(tttConsoleRunner);

            asking4PlayerState.Evaluate(HUMAN_PLAYER);

            ticTacToe.Verify(ttt => ttt.SetInitialPlayer(CellType.Opponent), Times.Once());
        }
    }
}