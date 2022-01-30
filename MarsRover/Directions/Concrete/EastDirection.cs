using MarsRover.Directions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Directions.Concrete
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
            if (_coordinates.X < _coordinates.SizeX)
                _coordinates.X += 1;
            else
                Console.WriteLine($"Sınır aşıldı. İleri gidilemiyor!! Max X : {_coordinates.SizeX}");
        }

        public IRoverState TurnLeft()
        {
            return new NorthDirection(_coordinates);
        }

        public IRoverState TurnRight()
        {
            return new SouthDirection(_coordinates);
        }

        public string GetDirection()
        {
            return "E";
        }
    }
}
