using MarsRover.Models.Directions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    internal class Rover
    {
        public IRoverState state { get; set; }

        public Rover(IRoverState state)
        {
            this.state = state;
        }

        public void Forward() => state.MoveForward();

        public void TurnRight() => this.state = state.TurnRight();   

        public void TurnLeft() => this.state = state.TurnLeft(); 

    }
}
