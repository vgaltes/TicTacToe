using System.Collections.Generic;
using TicTacToeGame.Console.Players;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticTacToe = CreateTicTacToe();
            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();
            var consoleIO = new ConsoleIO();

            var ticTacToeConsoleRunner = new TicTacToeConsoleRunner(ticTacToe, ticTacToeBoardDrawer, 
                consoleIO, new HumanPlayer(), new AIPlayer());

            ticTacToeConsoleRunner.Run();
        }

        private static ITicTacToe CreateTicTacToe()
        {
            var strategies = new List<TicTacToeStrategy>
            {
                new WinStrategy(),
                new BlockStrategy(),
                new ForkStrategy(),
                new BlockForkStrategy(),
                new CenterStrategy(),
                new OppositeCornerStrategy(),
                new FreeCornerStrategy(),
                new FreeSideStrategy()
            };

            var board = new Board();

            ITicTacToe ticTacToe = new TicTacToe(board, strategies);
            return ticTacToe;
        }
    }
}