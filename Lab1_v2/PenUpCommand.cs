using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2
{
    public class PenUpCommand: ICommandsWithoutArgs
    {
        public void Execute() { }
        public void Execute(Turtle turtle) {

            turtle.Set_penCondition(false);
            //Console.WriteLine("состояние: " + "перо поднято");

        }

        
    }
}
