using Lab1_v2;
using System.Linq;

internal class Program
{
    // файлы для записи команд черепашки
    private static string filePath = "commands_history.txt";
    private static string filePathFigures = "figures.txt";

    private static void Main(string[] args)
    {
        //инициализация вспомогательных объектов
        Turtle turtle = new Turtle();
        StorageReader storageReader = new StorageReader(filePath);
        StorageWriter storageWriter = new StorageWriter(filePath);
        StorageReader storageReaderForFigures = new StorageReader(filePathFigures);
        StorageWriter storageWriterForFigures = new StorageWriter(filePathFigures);


        CommandReader reader = new CommandReader();
        CommandManager manager = new CommandManager(storageReader, storageReaderForFigures);
        CommandInvoker Invoker = new CommandInvoker(turtle);
        NewFigureChecker checker = new NewFigureChecker(turtle, storageWriterForFigures);
        
        Notificator notificator = new Notificator();

        
        // список команда без аргументов и с аргументами
        List<string> commWithoutArgsList = new List<string>() { "penup", "pendown", "history" };
        List<string> commWithArgsList = new List<string>() { "move", "angle" , "color", "width"};

        // текст введенной команды
        string text;


        Console.WriteLine("-------Welcome to the TURTLEGAME-------");
        Console.WriteLine("Command list: \n" +
            "- move\n" +
            "- angle\n" + 
            "- penup\n" +
            "= pendown\n" + 
            "- history\n" + 
            "- listfigures\n" + 
            "- color\n" + 
            "- width");
        Console.WriteLine();
        Console.WriteLine("Choose the command from list to START the game");


        while (true)
        {
            text = reader.Read();

            if (text == "exit")
            {
                break;
            }

            else if (text == "history")
            {
                ICommandsWithoutArgs command = (ICommandsWithoutArgs)manager.DefineCommand(text);
                Invoker.Invoke(command);
                storageWriter.SaveCommand(text);
               
            }

            else if (text == "listfigures")
            {
                ICommandsWithoutArgs command = (ICommandsWithoutArgs)manager.DefineCommand(text);
                Invoker.Invoke(command);
            }

            else if (commWithoutArgsList.Contains(text))
            {
                ICommandsWithoutArgs command = (ICommandsWithoutArgs)manager.DefineCommand(text);
                Invoker.Invoke(command);
                storageWriter.SaveCommand(text);
                
                Console.WriteLine(notificator.SendCondition(turtle));

            }

            else if (commWithArgsList.Contains(text.Split(' ')[0]))
            {
                ICommandsWithArgs command = (ICommandsWithArgs)manager.DefineCommand(text.Split(' ')[0]);
                Invoker.Invoke(command, text.Split(' ')[1]);
                storageWriter.SaveCommand(text);
                Console.WriteLine(notificator.SendCondition(turtle));
            }
            else
            {
                Console.WriteLine("command doesn`t exist");
            } 
            
            checker.Check();
            
        }

        Console.WriteLine("GAME END");

        // очищение файла с командами
        storageWriter.ClearFile();
        storageWriterForFigures.ClearFile();
        //checker.ShowList();
       
;
    }



}