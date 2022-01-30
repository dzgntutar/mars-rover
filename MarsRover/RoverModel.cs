using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    internal class RoverModel
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int SizeX { get; set; }

        public int SizeY { get; set; }

        public string Direction { get; set; }

        public string RoverTask { get; set; }
    }
}
