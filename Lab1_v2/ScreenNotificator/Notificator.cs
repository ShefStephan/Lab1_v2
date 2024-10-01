using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_v2.TurtleObject;

namespace Lab1_v2.ScreenNotificator
{
    public class Notificator
    {
        public string ViewCondition(Turtle turtle)
        {
            return "состояние: " +
                "pos: (" + Math.Round(turtle.GetCoordX(), 2) +
                "; " + Math.Round(turtle.GetCoordY(), 2) + ")" +
                ", pen: " + turtle.GetPenCondition() +
                ", angle: " + turtle.GetAngle() +
                ", color: " + turtle.GetColor() +
                ", width: " + turtle.GetWidth();
        }

        //TODO либо здесь реализовать логику того, какую информацию надо выводить на экран
        // возможно добавить нотификейтор менеджер
    }
}
