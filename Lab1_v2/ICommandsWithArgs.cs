﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2
{
    internal interface ICommandsWithArgs: ICommands
    {
        public void Execute(string arg, Turtle turtle);
    }
}