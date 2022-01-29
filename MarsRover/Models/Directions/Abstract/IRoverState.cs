using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models.Directions.Abstract
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
