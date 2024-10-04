using Lab1_v2.Commands;
using Lab1_v2.CommandsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class ExceptionsTest
    {
        [Fact]
        public void Split_ShouldThrowIndexOutOfRangeException_WhenElementDoesNotExist()
        {

            string invalidKey = "sdfghjk";

            Assert.Throws<IndexOutOfRangeException>(() => invalidKey.Split(' ')[1]);
        }

        [Fact]
        public void ShouldThrowKeyNotFoundException_WhenElementDoesNotExistInDictionary()
        {
            Dictionary<string, ICommands> commands_Dict = new Dictionary<string, ICommands>() 
            {
                {"move", new MoveCommand()},
                {"penup", new PenUpCommand()},
                {"angle", new AngleCommand() },
                {"pendown", new PenDownCommand() },
                {"color", new SetColorCommand() } 
            };

            string invalidKey = "move/";

            Assert.Throws<KeyNotFoundException>(() => commands_Dict[invalidKey]);
        }

    }




}
