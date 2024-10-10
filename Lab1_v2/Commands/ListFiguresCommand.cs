using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_v2.CommandsInterface;
using Lab1_v2.Storage;
using Lab1_v2.TurtleObject;

namespace Lab1_v2.Commands
{
    public class ListFiguresCommand : ICommandsWithoutArgs
    {
        private StorageReader storageReader;
        public ListFiguresCommand(StorageReader reader)
        {
            storageReader = reader;
        }
        public void Execute(Turtle turtle)
        {
            storageReader.SetHistoryFiguresAsync();
        }
    }
}
