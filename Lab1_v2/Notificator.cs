using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2
{
    class Notificator
    {
        public string SendCondition(Turtle turtle)
        {
            return "состояние: " +
                "pos: (" + Math.Round(turtle.Get_c_x(), 2) +
                "; " + Math.Round(turtle.Get_c_y(), 2) + ")" +
                ", pen: " + turtle.Get_penCondition() +
                ", angle: " + turtle.Get_angle() +
                ", color: " + turtle.GetColor() +
                ", width: " + turtle.GetWidth();
        }
    }
}
