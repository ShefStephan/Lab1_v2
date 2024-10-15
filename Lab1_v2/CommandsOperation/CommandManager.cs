using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_v2.CommandsInterface;
using Lab1_v2.Storage;
using Lab1_v2.Commands;

namespace Lab1_v2.CommandsOperation
{
    public class CommandManager
    {
        private StorageReader reader;
        private StorageReader figuresReader;

        public CommandManager(StorageReader reader, StorageReader figuresReader)
        {
            this.reader = reader;
            this.figuresReader = figuresReader;
            FillDict();

        }

        private readonly Dictionary<string, ICommands> commandsDict = new() { };

        private void FillDict()
        {
            commandsDict.Add("history", new HistoryCommand(reader));
            commandsDict.Add("listfigures", new ListFiguresCommand(figuresReader));
            commandsDict.Add("move", new MoveCommand());
            commandsDict.Add("penup", new PenUpCommand());
            commandsDict.Add("angle", new AngleCommand());
            commandsDict.Add("pendown", new PenDownCommand());
            commandsDict.Add("color", new SetColorCommand());
            commandsDict.Add("width", new SetWidthCommand());


        }


        public ICommands DefineCommand(string command)
        {
            return commandsDict[command];
        }
    }
}
