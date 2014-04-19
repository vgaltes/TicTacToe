using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console.TicTacToeConsoleRunnerStates
{
    public class AskingForPlayerTTTConsoleRunner : TicTacToeConsoleRunner
    {
        private string extraInfo = string.Empty;

        public AskingForPlayerTTTConsoleRunner(TicTacToeConsoleRunner consoleRunner)
        {
            this.consoleIO = consoleRunner.consoleIO;
            this.ticTacToe = consoleRunner.ticTacToe;
            this.ticTacToeBoardDrawer = consoleRunner.ticTacToeBoardDrawer;
        }

        public override void Run()
        {
            SetInitialPlayer();
            DrawBoard();
        }

        private void SetInitialPlayer()
        {
            consoleIO.Clear();
            consoleIO.WriteLine(Resources.SelectPlayer);
            var option = consoleIO.ReadLine();
            if (option != AI_PLAYER && option != HUMAN_PLAYER)
                SetInitialPlayer();
            else
            {
                var initialPlayer = (CellType)Enum.Parse(typeof(CellType), option);
                ticTacToe.SetInitialPlayer(initialPlayer);
                extraInfo = Resources.WriteCoordinates;
            }
        }
    }
}
