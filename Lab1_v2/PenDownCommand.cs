using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2
{
    internal class PenDownCommand: ICommandsWithoutArgs
    {
        public void Execute() { }
        public void Execute(Turtle turtle)
        {

            turtle.Set_penCondition(true);
            //Console.WriteLine("состояние: " + "перо поднято");

        }


    }
}
