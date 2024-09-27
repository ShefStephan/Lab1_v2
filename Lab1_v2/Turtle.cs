using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2
{
    internal class Turtle
    {
        double c_x;
        double c_y;
        bool penCondition;
        double angle;
        string color;
        double width;


        public Turtle() {
            c_x = 0;
            c_y = 0;
            angle = 0;
            penCondition = true;
            color = "black";
            width = 1;
       
        }

        public double Get_c_x()
        {
            return c_x;
        }

        public void Set_c_x(double value)
        {
            c_x += value;
        }

        public double Get_c_y()
        {
            return c_y;
        }

        public void Set_c_y(double value)
        {
            c_y += value;
        }


        public double Get_angle() 
        { 
            return angle; 
        }

        public void Set_angle(double value)
        {
            angle = (angle + value) % 360;
        }


        public string Get_penCondition()
        {
            if (penCondition) {
                return "penDown";
            }

            return "penUp";
        }

        public void Set_penCondition(bool value) 
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
