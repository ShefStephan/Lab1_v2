using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2
{
    public class SetColorCommand : ICommandsWithArgs
    {
        public void Execute(string arg, Turtle turtle)
        {
            turtle.SetColor(arg);
            
        }

        public void Execute()
        {
            
        }
    }
}
