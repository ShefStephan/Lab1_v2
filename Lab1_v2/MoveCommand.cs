using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2
{
    public class MoveCommand: ICommandsWithArgs
    {

        public void Execute(string str, Turtle turtle)
        {

            turtle.Set_c_x(double.Parse(str)
                * Math.Sin(turtle.Get_angle() * (Math.PI / 180)));

            turtle.Set_c_y(double.Parse(str)
                * Math.Cos(turtle.Get_angle() * (Math.PI / 180)));

        }

        public void Execute()
        {
            
        }
    }
}
