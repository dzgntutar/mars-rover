using MarsRover.Models;
using MarsRover.Models.Directions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models.Directions.Concrete
{
    //Doğu
    internal class EastDirection : IRoverState
    {
        public Coordinate _coordinates { get; set; }

        public EastDirection(Coordinate coordinates)
        {
            _coordinates = coordinates;
        }

        public void MoveForward()
        {
            _coordinates.X += 1;
        }

        public IRoverState TurnLeft()
        {
            return new NorthDirection(_coordinates);
        }

        public IRoverState TurnRight()
        {
            return new SouthDirection(_coordinates);
        }
    }
}
