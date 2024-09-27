using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2
{
    internal class ListFiguresCommand: ICommandsWithoutArgs
    {
        private StorageReader storageReader;
        public ListFiguresCommand(StorageReader reader)
        {
            storageReader = reader;
        }
        public void Execute() { }
        public void Execute (Turtle turtle) 
        {
            storageReader.ShowHistory();
        }
    }
}
