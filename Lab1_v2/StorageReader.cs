using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2
{
    internal class StorageReader
    {
        private string filePath;

        public StorageReader(string path)
        {
            filePath = path;
        }

        public void ShowHistory()
        {
            string[] commands = File.ReadAllLines(filePath);

            if (commands.Length > 0)
            {
                foreach (string command in commands)
                {
                    Console.WriteLine("· " + command);
                }
            }
            else
            {
                Console.WriteLine("здесь пусто...");
            }
        }

        public void ShowHistoryFigures()
        {
            string[] commands = File.ReadAllLines(filePath);

            if (commands.Length > 0)
            {
                foreach (string command in commands)
                {
                    Console.WriteLine("· " + command);
                }
            }
            else
            {
                Console.WriteLine("здесь пусто...");
            }
        }

    }
}
