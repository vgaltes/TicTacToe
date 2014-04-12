using System.Collections.Generic;

namespace TicTacToeGame.Models
{
    public class Line
    {
        public List<CellCoordinates> Coordinates = new List<CellCoordinates>();

        public Line(CellCoordinates start, CellCoordinates middle, CellCoordinates end)
        {
            Coordinates.Add(start);
            Coordinates.Add(middle);
            Coordinates.Add(end);
        }
    }
}