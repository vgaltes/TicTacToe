﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame.Console
{
    public class ConsoleIO
    {
        private const string HORIZONTAL_SEPARATOR = "-----------------------------------------------";
        private const string VERTICAL_SEPARATOR = "|";
        private const string PROMPT = "> ";

        public virtual void WriteLine(string line)
        {
            System.Console.WriteLine(line);
        }

        public virtual void Write(string line)
        {
            System.Console.Write(line);
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

        internal void WriteHorizontalSeparator()
        {
            System.Console.WriteLine(HORIZONTAL_SEPARATOR);
        }

        internal void WritePrompt()
        {
            System.Console.Write(PROMPT);
        }
        
        internal void SetForegroundColor(ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
        }

        internal void ResetColor()
        {
            System.Console.ResetColor();
        }
    }
}