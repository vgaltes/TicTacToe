using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Models;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var ticTacToeGameRunner = new TicTacToeConsoleRunner(CreateTicTacToe());
            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();
            var boardAsString = ticTacToeBoardDrawer.GetRepresentationOf(ticTacToeGameRunner.GetBoard());
            System.Console.WriteLine(boardAsString);
            string line = System.Console.ReadLine();
            do
            {
                int[] coordinates = line.Split(',').Select(c => int.Parse(c)).ToArray();

                ticTacToeGameRunner.Play(new CellCoordinates(coordinates[0], coordinates[1]));

                boardAsString = ticTacToeBoardDrawer.GetRepresentationOf(ticTacToeGameRunner.GetBoard());
                System.Console.WriteLine(boardAsString);
                line = System.Console.ReadLine();
            } while (line != "q!");
        }

        private static TicTacToe CreateTicTacToe()
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

            return new TicTacToe(strategies);
        }
    }
}
