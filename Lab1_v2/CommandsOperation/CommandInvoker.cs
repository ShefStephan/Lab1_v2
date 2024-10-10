using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_v2.CommandsInterface;
using Lab1_v2.TurtleObject;

namespace Lab1_v2.CommandsOperation
{
    public class CommandInvoker
    {

        private Turtle turtle;

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
            comm.Execute(turtle, arg);
        }
    }
}
