using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_v2.CommandsInterface;
using Lab1_v2.TurtleObject;

namespace Lab1_v2.Commands
{
    public class AngleCommand : ICommandsWithArgs
    {
        public void Execute(Turtle turtle, string str)
        {

            turtle.SetAngle(int.Parse(str));

        }
        
    }
}
