using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2
{
    internal class CommandInvoker
    {

        Turtle turtle;

        public CommandInvoker(Turtle turtle)
        {
            this.turtle = turtle;
        }

        public void Invoke(ICommandsWithoutArgs comm)
        {
            comm.Execute(turtle);
        }

        public void Invoke(ICommandsWithArgs comm, string arg)
        {
            comm.Execute(arg, turtle);
        }
    }
}
