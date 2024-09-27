using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2
{
    internal class CommandManager 
    {
        ICommands comm;
        private StorageReader reader;
        private StorageReader figuresReader;

        public CommandManager(StorageReader reader, StorageReader figuresReader)
        {
            this.reader = reader;
            this.figuresReader = figuresReader;
            fillDict();

        }

        Dictionary<string, ICommands> commands_Dict = new Dictionary<string, ICommands>() { };

        private void fillDict()
        {
            commands_Dict.Add("history", new HistoryCommand(reader));
            commands_Dict.Add("listfigures", new ListFiguresCommand(figuresReader));
            commands_Dict.Add("move", new MoveCommand());
            commands_Dict.Add("penup", new PenUpCommand());
            commands_Dict.Add("angle", new AngleCommand());
            commands_Dict.Add("pendown", new PenDownCommand());
            commands_Dict.Add("color", new SetColorCommand());
            commands_Dict.Add("width", new SetWidthCommand());


        }


        public ICommands DefineCommand(string command)
        {
            return commands_Dict[command];            

        }
    }
}
