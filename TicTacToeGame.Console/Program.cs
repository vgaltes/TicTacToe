using System.Collections.Generic;
using TicTacToeGame.Console.Players;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();
            var consoleIO = new ConsoleIO();
            var board = new Board();

            var strategies = new List<TicTacToeStrategy>
            {
                new WinStrategy('O', 'X'),
                new BlockStrategy('O', 'X'),
                new ForkStrategy('O', 'X'),
                new BlockForkStrategy('O', 'X'),
                new CenterStrategy('O', 'X'),
                new OppositeCornerStrategy('O', 'X'),
                new FreeCornerStrategy('O', 'X'),
                new FreeSideStrategy('O', 'X')
            };

            var ticTacToeConsoleRunner = new TicTacToeConsoleRunner(board, ticTacToeBoardDrawer,
                consoleIO, new AIPlayer(consoleIO, strategies, 'O'), new HumanPlayer(consoleIO, 'X'));

            ticTacToeConsoleRunner.Run();
        }
        
    }
}