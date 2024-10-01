﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_v2.TurtleObject;

namespace Lab1_v2.Storage
{
    public class NewFigureChecker
    {
        private string path;
        private Turtle turtle;
        private List<(double x, double y)> points = new List<(double x, double y)>() { };
        private double lastX;
        private double lastY;
        private string figure;
        private StorageWriter writer;


        public NewFigureChecker(Turtle turtle, StorageWriter writer)
        {
            this.turtle = turtle;
            points.Add((0, 0));
            lastX = points[0].x;
            lastY = points[0].y;
            this.writer = writer;
        }



        public void Check()
        {
            if (turtle.GetPenCondition() == "penDown")
            {
                if (lastX != Math.Round(turtle.GetCoordX(), 2) || lastY != Math.Round(turtle.GetCoordY(), 2))
                {
                    points.Add((Math.Round(turtle.GetCoordX(), 2), Math.Round(turtle.GetCoordY(), 2)));

                    lastX = points[points.Count - 1].x;
                    lastY = points[points.Count - 1].y;


                    if (points.Count > 1 && points[0] == points[^1])
                    {

                        switch (points.Count - 1)
                        {
                            case 3:
                                figure = "треугольник";
                                break;
                            case 4:
                                figure = "квадрат";
                                break;
                            case 5:
                                figure = "пятиугольник";
                                break;
                            case 6:
                                figure = "шестиугольник";
                                break;
                            case 7:
                                figure = "семиугольник";
                                break;

                        }

                        Console.Write("Образована новая фигура: " + figure);
                        Console.WriteLine();

                        writer.SaveCommand(figure + " " + ListToString());
                        points.Clear();
                    }
                }
            }
            else
            {
                points.Clear();
            }

        }



        public string ListToString()
        {
            string listString = "{";
            foreach (var point in points)
            {
                listString += "(" + point.x + ";" + point.y + ")";
            }
            return listString + "}";
        }

    }
}