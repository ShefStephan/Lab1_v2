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
        private string[] commands;
        private string[] figures;

        public StorageReader(string path)
        {
            filePath = path;
        }

        
        public async Task SetHistoryAsync()
        {
            commands = await File.ReadAllLinesAsync(filePath);
        }

        public string[] GetHistory()
        {
            return commands;
        }

        public async Task SetHistoryFiguresAsync()
        {
            figures = await File.ReadAllLinesAsync(filePath);
        }

        public string[] GetFigures()
        {
            return figures;
        }


    }
}
