using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Directions.Abstract
{
    internal interface IRoverState
    {
        Coordinate _coordinates { get; set; }
        void MoveForward();
        IRoverState TurnLeft();
        IRoverState TurnRight();
        string GetDirection();
    }
}
