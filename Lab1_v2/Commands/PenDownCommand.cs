using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_v2.CommandsInterface;
using Lab1_v2.TurtleObject;

namespace Lab1_v2.Commands
{
    public class PenDownCommand : ICommandsWithoutArgs
    {
        public void Execute() { }
        public void Execute(Turtle turtle)
        {

            turtle.SetPenCondition(true);
            //Console.WriteLine("состояние: " + "перо поднято");

        }


    }
}
