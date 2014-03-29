using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var ticTacToeGameRunner = new TicTacToeConsoleRunner(new TicTacToe());
            var ticTacToeBoardDrawer = new TicTacToeBoardDrawer();
            var boardAsString = ticTacToeBoardDrawer.GetRepresentationOf(ticTacToeGameRunner.GetBoard());
            System.Console.WriteLine(boardAsString);
            string line = System.Console.ReadLine();
            do
            {
                int[] coordinates = line.Split(',').Select(c => int.Parse(c)).ToArray();

                ticTacToeGameRunner.Play(coordinates[0], coordinates[1]);

                boardAsString = ticTacToeBoardDrawer.GetRepresentationOf(ticTacToeGameRunner.GetBoard());
                System.Console.WriteLine(boardAsString);
                line = System.Console.ReadLine();
            } while (line != "q!");
        }
    }
}
