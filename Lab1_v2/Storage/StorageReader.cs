using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2.Storage
{
    public class StorageReader
    {
        private string filePath;
        private string[] historyMass;
        private string[] figuresMass;

        public StorageReader(string path)
        {
            filePath = path;
        }


        // TODO 1 - сделать проверку нужно ли вообще вызывать метод 
        // 2 - либо менеджер вызовов
        // TODO прочитать про async и await в доке с лабой
        public async string[] GetHistory()

        {
            Task<string[]> commands = File.ReadAllLinesAsync(filePath);
            historyMass = await commands;

            return historyMass;


            //if (commands.Length > 0)
            //{
            //    foreach (string command in commands)
            //    {
            //        Console.WriteLine("· " + command);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("здесь пусто...");
            //}
        }

        //TODO запись истории в список
        public string[] GetHistoryFigures()
        {
            Task<string[]> commands = File.ReadAllLinesAsync(filePath);
            figuresMass = commands.Result;


            return figuresMass;

            //if (commandsMass.Length > 0)
            //{
            //    foreach (string command in commands)
            //    {
            //        Console.WriteLine("· " + command);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("здесь пусто...");
            //}
        }

    }
}
