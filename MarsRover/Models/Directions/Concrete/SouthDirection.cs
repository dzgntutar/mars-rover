using MarsRover.Models;
using MarsRover.Models.Directions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models.Directions.Concrete
{
    // Güney
    internal class SouthDirection : IRoverState
    {
        public Coordinate _coordinates { get; set; }

        public SouthDirection(Coordinate coordinates)
        {
            _coordinates = coordinates;
        }

        public void MoveForward()
        {
            _coordinates.Y -= 1;
        }

        public IRoverState TurnLeft()
        {
            return new EastDirection(_coordinates);
        }

        public IRoverState TurnRight()
        {
            return new WestDirection(_coordinates);
        }
    }
}
