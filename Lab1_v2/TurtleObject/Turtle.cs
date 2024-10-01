using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_v2.Commands;


namespace Lab1_v2.TurtleObject
{
    public class Turtle
    {
        double coordX;
        double coordY;
        bool penCondition;
        double angle;
        string color;
        double width;


        public Turtle()
        {
            coordX = 0;
            coordY = 0;
            angle = 0;
            penCondition = true;
            color = "black";
            width = 1;

        }

        public double GetCoordX()
        {
            return coordX;
        }

        public void SetCoordx(double value)
        {
            coordX += value;
        }

        public double GetCoordY()
        {
            return coordY;
        }

        public void SetCoordY(double value)
        {
            coordY += value;
        }


        public double GetAngle()
        {
            return angle;
        }

        public void SetAngle(double value)
        {
            angle = (angle + value) % 360;
        }


        public string GetPenCondition()
        {
            if (penCondition)
            {
                return "penDown";
            }

            return "penUp";
        }

        public void SetPenCondition(bool value)
        {
            penCondition = value;
        }

        public void SetColor(string value)
        {
            color = value;
        }

        public string GetColor()
        {
            return color;
        }

        public void SetWidth(double value)
        {
            width = value;
        }

        public double GetWidth()
        {
            return width;
        }

    }

}
