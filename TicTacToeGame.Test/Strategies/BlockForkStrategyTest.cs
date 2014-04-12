﻿using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Test.Strategies
{
    [TestFixture]
    public class BlockForkStrategyTest
    {
        [Test]
        public void GivenThereIsAnAICellInTheFirstCorner_CanHandleReturnsFalse()
        {
            var blockForkStrategy = new BlockForkStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithAMark(Mark.AIFromCoordinates(0, 0));
            var canHandle = blockForkStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [Test]
        public void GivenThereAreCellsInTheFirstQuarter_CanHandleReturnsFalse()
        {
            var blockForkStrategy = new BlockForkStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>{
                Mark.AIFromCoordinates(0, 0),
                Mark.OpponentFromCoordinates(0, 1),
                Mark.OpponentFromCoordinates(1, 0),
                Mark.OpponentFromCoordinates(1, 1),
            });

            var canHandle = blockForkStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [Test]
        public void GivenThereIsAnAICellInTheSecondCornerAndAnOpponentCellInTheFirstCorner_CanHandleReturnsFalse()
        {
            var blockForkStrategy = new BlockForkStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>{
                Mark.OpponentFromCoordinates(0,0),
                Mark.AIFromCoordinates(0, 2)
            });

            var canHandle = blockForkStrategy.CanHandle(initialBoard);

            canHandle.Should().BeFalse();
        }

        [Test]
        public void GivenThereIsAnAICellInTheSecondCornerAndOpponentCellsInTheFirstCornerAndThirdCorner_CanHandleReturnsTrue()
        {
            var blockForkStrategy = new BlockForkStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>{
                Mark.OpponentFromCoordinates(0,0),
                Mark.AIFromCoordinates(0, 2),
                Mark.OpponentFromCoordinates(2,2)
            });

            var canHandle = blockForkStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }

        [Test]
        public void GivenThereIsAnAICellInTheSecondCornerAndOpponentCellsInTheFirstCornerAndThirdCorner_UpdatePutsAMarkInTheFirstSide()
        {
            var blockForkStrategy = new BlockForkStrategy();

            var initialBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>{
                Mark.OpponentFromCoordinates(0,0),
                Mark.AIFromCoordinates(0, 2),
                Mark.OpponentFromCoordinates(2,2)
            });
            blockForkStrategy.Update(initialBoard);

            var expectedBoard = BoardTestHelper.GetABoardWithMarks(new List<Mark>{
                Mark.OpponentFromCoordinates(0,0),
                Mark.AIFromCoordinates(0, 2),
                Mark.OpponentFromCoordinates(2,2),
                Mark.AIFromCoordinates(1, 1)
            });

            var canHandle = blockForkStrategy.CanHandle(initialBoard);

            canHandle.Should().BeTrue();
        }
    }}