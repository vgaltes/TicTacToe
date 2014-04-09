using System.Collections.Generic;

namespace TicTacToeGame.Models
{
    public class Line
    {
        public List<MarkCoordinate> Coordinates = new List<MarkCoordinate>();

        public Line(MarkCoordinate start, MarkCoordinate middle, MarkCoordinate end)
        {
            Coordinates.Add(start);
            Coordinates.Add(middle);
            Coordinates.Add(end);
        }
    }
}