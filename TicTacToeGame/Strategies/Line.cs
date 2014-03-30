using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Strategies
{
    public class Line
    {
        public MarkCoordinate LineStart { get; private set; }
        public MarkCoordinate LineEnd { get; private set; }
        public MarkCoordinate Evaluate { get; private set; }

        public Line(MarkCoordinate start, MarkCoordinate middle, MarkCoordinate end)
        {
            LineStart = start;
            LineEnd = middle;
            Evaluate = end;
        }
    }
}