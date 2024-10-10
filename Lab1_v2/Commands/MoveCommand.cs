using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_v2.CommandsInterface;
using Lab1_v2.TurtleObject;

namespace Lab1_v2.Commands
{
    public class MoveCommand : ICommandsWithArgs
    {

        public void Execute(Turtle turtle, string str)
        {

            turtle.SetCoordx(double.Parse(str)
                * Math.Sin(turtle.GetAngle() * (Math.PI / 180)));

            turtle.SetCoordY(double.Parse(str)
                * Math.Cos(turtle.GetAngle() * (Math.PI / 180)));

        }
        
    }
}
