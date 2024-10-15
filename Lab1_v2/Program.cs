using Lab1_v2.CommandsInterface;
using Lab1_v2.CommandsOperation;
using Lab1_v2.ScreenNotificator;
using Lab1_v2.Storage;
using Lab1_v2.TurtleObject;
using System.Linq;

internal class Program
{
    // файлы для записи команд черепашки
    private const string filePath = "commands_history.txt";
    private const string filePathFigures = "figures.txt";
    private const string Exit = "exit";

    private static async Task Main(string[] args)
    {
        //инициализация вспомогательных объектов
        var turtle = new Turtle();
        var storageReader = new StorageReader(filePath);
        var storageWriter = new StorageWriter(filePath);
        var storageReaderForFigures = new StorageReader(filePathFigures);
        var storageWriterForFigures = new StorageWriter(filePathFigures);


        var reader = new CommandReader();
        var manager = new CommandManager(storageReader, storageReaderForFigures);
        var invoker = new CommandInvoker(turtle);
        var checker = new NewFigureChecker(turtle, storageWriterForFigures);
        var notificator = new Notificator(storageReader, storageReaderForFigures);


        // список команда без аргументов и с аргументами
        var commWithoutArgsList = new List<string>() { "penup", "pendown", "history", "listfigures" };
        //List<string> commWithArgsList = new List<string>() { "move", "angle" , "color", "width"};

        // текст введенной пользователем команды
        string userCommand;


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

                if (userCommand == Exit)
                {
                    break;
                }

                if (commWithoutArgsList.Contains(userCommand))
                {
                    ICommandsWithoutArgs command = (ICommandsWithoutArgs)manager.DefineCommand(userCommand);
                    invoker.Invoke(command);
                    await storageWriter.SaveCommandAsync(userCommand);
                }
                else
                {
                    ICommandsWithArgs command = (ICommandsWithArgs)manager.DefineCommand(userCommand.Split(' ')[0]);
                    invoker.Invoke(command, userCommand.Split(' ')[1]);
                    await storageWriter.SaveCommandAsync(userCommand);
                }

                // вывод соообщение после испольнения команды
                notificator.SendNotification(userCommand, turtle);

                // проверка на образование новой фигуры
                await checker.Check();
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
        await storageWriter.ClearFileAsync();
        await storageWriterForFigures.ClearFileAsync();

        ;
    }
}