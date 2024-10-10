using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_v2.Storage;
using Lab1_v2.TurtleObject;

namespace Lab1_v2.ScreenNotificator
{
    public class Notificator
    {
        private StorageReader historyCommandReader;
        private StorageReader historyFiguresReader;

        public Notificator(StorageReader historyCommandReader, StorageReader historyFiguresReader)
        {
            this.historyCommandReader = historyCommandReader;
            this.historyFiguresReader = historyFiguresReader;
        }


        public void SendNotification(string command, Turtle turtle)
        {
            if (command == "history")
            {
                foreach (var comm in historyCommandReader.GetHistory())
                {
                    Console.WriteLine("· " + comm);
                }
               
            }

            else if (command == "listfigures")
            {
                foreach (var figure in historyFiguresReader.GetFigures())
                {
                    Console.WriteLine("· " + figure);
                }
            }

            else
            {
                Console.WriteLine("состояние: " +
                "pos: (" + Math.Round(turtle.GetCoordX(), 2) +
                "; " + Math.Round(turtle.GetCoordY(), 2) + ")" +
                ", pen: " + turtle.GetPenCondition() +
                ", angle: " + turtle.GetAngle() +
                ", color: " + turtle.GetColor() +
                ", width: " + turtle.GetWidth());
            }
           
        }

        
        
    }
}
