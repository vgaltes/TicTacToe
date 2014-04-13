using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame.Console
{
    public class ConsoleIO
    {
        public virtual void WriteLine(string line)
        {
            System.Console.WriteLine(line);
        }

        public virtual string ReadLine()
        {
            return System.Console.ReadLine();
        }

        public virtual void Clear()
        {
            System.Console.Clear();
        }

        public virtual void ReadKey()
        {
            System.Console.ReadKey();
        }
    }
}
