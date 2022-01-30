using MarsRover.Directions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Directions.Concrete
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
            if (_coordinates.X > 0)
                _coordinates.X -= 1;
            else
                Console.WriteLine($"Sınır aşıldı. İleri gidilemiyor!! Min : 0");

        }

        public IRoverState TurnLeft()
        {
            return new SouthDirection(_coordinates);
        }

        public IRoverState TurnRight()
        {
            return new NorthDirection(_coordinates);
        }
        public string GetDirection()
        {
            return "W";
        }
    }
}
