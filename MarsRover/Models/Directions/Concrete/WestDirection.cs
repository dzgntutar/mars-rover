using MarsRover.Models;
using MarsRover.Models.Directions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models.Directions.Concrete
{
    //Batı
    internal class WestDirection : IRoverState
    {
        public Coordinate _coordinates { get; set; }

        public WestDirection(Coordinate coordinates)
        {
            _coordinates = coordinates;
        }

        public void MoveForward()
        {
            _coordinates.X -= -1;
        }

        public IRoverState TurnLeft()
        {
            return new SouthDirection(_coordinates);
        }

        public IRoverState TurnRight()
        {
            return new NorthDirection(_coordinates);
        }
    }
}
