using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2
{
    class AngleCommand: ICommandsWithArgs
    {
        public void Execute(string str, Turtle turtle)
        {

            turtle.Set_angle(int.Parse(str));

        }

        public void Execute()
        {

        }
    }
}
