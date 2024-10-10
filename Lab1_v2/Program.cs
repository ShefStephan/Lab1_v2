using Lab1_v2.CommandsInterface;
using Lab1_v2.CommandsOperation;
using Lab1_v2.ScreenNotificator;
using Lab1_v2.Storage;
using Lab1_v2.TurtleObject;
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
        Notificator notificator = new Notificator(storageReader, storageReaderForFigures);

        
        // список команда без аргументов и с аргументами
        List<string> commWithoutArgsList = new List<string>() { "penup", "pendown", "history", "listfigures"};
        //List<string> commWithArgsList = new List<string>() { "move", "angle" , "color", "width"};

        // текст введенной пользователем команды
        string userCommand;


        //solid  - s ?
        // S - Принцип единственной ответственности
        // O - 
        // L - 
        // I - 
        // D - 

        Console.WriteLine("-------Welcome to the TURTLEGAME-------");
        Console.WriteLine();
        Console.WriteLine("Command list: \n" +
            "- move [number]\n" +
            "- angle [number]\n" + 
            "- penup\n" +
            "= pendown\n" + 
            "- history\n" + 
            "- listfigures\n" + 
            "- color [string]\n" + 
            "- width [number]");
        Console.WriteLine();
        Console.WriteLine("Choose the command from list to START the game");


        while (true)
        {
            try
            {
                userCommand = reader.Read();

                if (userCommand == "exit")
                {
                    break;
                }

                if (commWithoutArgsList.Contains(userCommand))
                {
                    ICommandsWithoutArgs command = (ICommandsWithoutArgs)manager.DefineCommand(userCommand);
                    Invoker.Invoke(command);
                    storageWriter.SaveCommandAsync(userCommand);

                }

                else
                {
                    ICommandsWithArgs command = (ICommandsWithArgs)manager.DefineCommand(userCommand.Split(' ')[0]);
                    // visitor or remove invoker
                    Invoker.Invoke(command, userCommand.Split(' ')[1]);
                    storageWriter.SaveCommandAsync(userCommand);
                }



                // вывод соообщение после испольнения команды
                notificator.SendNotification(userCommand, turtle);

                // проверка на образование новой фигуры
                checker.Check();
            }


            // возможные ошибки в ходе выполнения
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Invalid argument");
            }

            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Invalid argument, or argument doesn`t exist");
            }

            catch (KeyNotFoundException ex)
            {
                Console.WriteLine("Invalid command, or command doesn`t exist");
            }

            catch (FormatException ex)
            {
                Console.WriteLine("Invalid argument, please try again or check command list");
            }

            catch (NullReferenceException ex)
            {
                Console.WriteLine("empty...");
            }



        }

        Console.WriteLine("GAME END");

        // очищение файла с командами и фигурами
        storageWriter.ClearFile();
        storageWriterForFigures.ClearFile();
       
;
    }



}