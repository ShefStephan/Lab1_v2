using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2
{
    internal class NewFigureChecker
    {
        private string path;
        private Turtle turtle;
        private List<(double x, double y)> points = new List<(double x, double y)>() { };
        private double last_x;
        private double last_y;
        private string figure;
        private StorageWriter writer;
        

        public NewFigureChecker(Turtle turtle, StorageWriter writer)
        {
            this.turtle = turtle;
            points.Add((0, 0));
            last_x = points[0].x;
            last_y = points[0].y;
            this.writer = writer;
        }



        public void Check()
        {
            if (turtle.Get_penCondition() == "penDown")
            {
                if (last_x != Math.Round(turtle.Get_c_x(), 2) || last_y != Math.Round(turtle.Get_c_y(), 2))
                {
                    points.Add((Math.Round(turtle.Get_c_x(), 2), Math.Round(turtle.Get_c_y(), 2)));

                    last_x = points[points.Count - 1].x;
                    last_y = points[points.Count - 1].y;


                    if (points.Count > 1 && points[0] == points[^1])
                    {
                        
                        switch (points.Count-1)
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
