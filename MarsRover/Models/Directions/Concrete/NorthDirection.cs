using MarsRover.Models.Directions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models.Directions.Concrete
{
    //Kuzey
    internal class NorthDirection : IRoverState
    {
        public Coordinate _coordinates { get; set; }

        public NorthDirection(Coordinate coordinates)
        {
            _coordinates = coordinates;
        }

        public void MoveForward()
        {
            if (_coordinates.Y < _coordinates.SizeY)
                _coordinates.Y += 1;
            else
                Console.WriteLine($"Sınır aşıldı. İleri gidilemiyor!! Max Y : {_coordinates.SizeY}");
        }

        public IRoverState TurnLeft()
        {
            return new WestDirection(_coordinates);
        }

        public IRoverState TurnRight()
        {
            return new EastDirection(_coordinates);
        }

        public string GetDirection()
        {
            return "N";
        }
    }
}
