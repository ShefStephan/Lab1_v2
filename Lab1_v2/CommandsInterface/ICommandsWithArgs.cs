using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_v2.TurtleObject;

namespace Lab1_v2.CommandsInterface
{
    public interface ICommandsWithArgs : ICommands
    {
        void Execute(Turtle turtle, string arg = null);
    
    }
}
