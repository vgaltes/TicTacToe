using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TicTacToeGame.Console.Players;
using TicTacToeGame.Models;
using TicTacToeGame.Strategies;
using TicTacToeGame.Test.Fakes;

namespace TicTacToeGame.Console.Test.Players
{
    [TestFixture]
    public class AIPlayerTest
    {
        Mock<ConsoleIO> consoleIO;
        Mock<Board> board;
        AIPlayer aiPlayer;

        [SetUp]
        public void TestSetUp()
        {
            consoleIO = new Mock<ConsoleIO>();
            board = new Mock<Board>();
            aiPlayer = new AIPlayer(consoleIO.Object, new List<TicTacToeStrategy>{new AllwaysUpdateStrategy()}, 'O');
        }

        [Test]
        public void WritesAskForCoordinatesMessage()
        {
            aiPlayer.AskForUserInput();

            consoleIO.Verify(c => c.WriteLine(Resources.AIIsGonnaMove));
            consoleIO.Verify(c => c.ReadLine());
        }

        [Test]
        public void WhenMoving_CallTicTacTocAIMove()
        {
            aiPlayer.Move(board.Object, string.Empty);

            board.Verify(b => b.FillCell(It.IsAny<CellCoordinates>(), 'O'));
        }
    }
}