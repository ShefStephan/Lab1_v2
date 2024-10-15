using Lab1_v2.Commands;
using Lab1_v2.Storage;
using Lab1_v2.TurtleObject;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using Moq;


namespace TestProject1
{
    public class TurtleCommandTest
    {

        //тестовые данные
        [Theory]
        [InlineData("-5", 0, -5)]
        [InlineData("0", 0, 0)]
        [InlineData("10", 0, 10)]
        public void TestMoveCommandWithExtremePointsData(string str, double expX, double expY)
        {

            Turtle turtle = new Turtle();
            MoveCommand moveCommand = new MoveCommand();

            string command = str;
            double expectedX = expX;
            double expectedY = expY;

            //действие
            moveCommand.Execute(turtle, command);
            double actualX = turtle.GetCoordX();
            double actualY = turtle.GetCoordY();

            //проверка
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);

        }

        [Fact]
        public void TestMoveCommandWithRandomData()
        {
            // инициализация
            Random rnd = new Random();
            Turtle turtle = new Turtle();
            MoveCommand moveCommand = new MoveCommand();

            //данные
            string command = rnd.Next(1000).ToString();
            double expectedY = double.Parse(command);

            //действие
            moveCommand.Execute(turtle, command);

            //проверка
            Assert.Equal(0, turtle.GetCoordX());
            Assert.Equal(expectedY, turtle.GetCoordY());

        }


        [Theory]
        [InlineData("120", 120)]
        [InlineData("400", 40)]
        [InlineData("-120", -120)]
        [InlineData("0", 0)]

        public void TestAngleCommandWithExtremePointsData(string str, double exp)
        {
            //тестовые данные
            Turtle turtle = new Turtle();
            AngleCommand angleCommand = new AngleCommand();
            string command = str;
            double expected = exp;


            //действие
            angleCommand.Execute(turtle, command);
            double actual = turtle.GetAngle();

            //проверка
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestPenUpCommandResult()
        {
            //тестовые данные
            Turtle turtle = new Turtle();
            PenUpCommand penUpCommand = new PenUpCommand();
            string expected = "penUp";

            penUpCommand.Execute(turtle);
            string actual = turtle.GetPenCondition();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestPenDownCommandResult()
        {
            //тестовые данные
            Turtle turtle = new Turtle();
            PenDownCommand penDownCommand = new PenDownCommand();
            string expected = "penDown";

            penDownCommand.Execute(turtle);
            string actual = turtle.GetPenCondition();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestSetColorCommandResult()
        {
            //тестовые данные
            Turtle turtle = new Turtle();
            SetColorCommand setColorCommand = new SetColorCommand();
            string command = "red";
            string expected = "red";


            //действие
            setColorCommand.Execute(turtle, command);
            string actual = turtle.GetColor();

            //проверка
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestSetWidthCommandWithRandomData()
        {
            //тестовые данные
            Random rnd = new Random();
            Turtle turtle = new Turtle();
            SetWidthCommand setWidthCommand = new SetWidthCommand();
            string command = rnd.Next(1000).ToString();
            double expected = int.Parse(command);


            //действие
            setWidthCommand.Execute(turtle, command);
            double actual = turtle.GetWidth();

            //проверка
            Assert.Equal(expected, actual);

        }
        
        
        
        
            [Theory]
            [InlineData("move 5", "angle 90", "penup")]
            [InlineData("pendown", "penup", "move 5")]
            [InlineData("angle 78", "history", "width 10")]
            [InlineData("pendown", "color red", "move -5")]
            [InlineData("move 33", "penup", "history")]
            public void TestHistoryCommandWithInlineDataWithMoq(params string[] commands)
            {
                var mockStorageWriter = new Mock<IStorageWriter>();

                // Кписок хранения команд
                var savedCommands = new List<string>();

                // Мок
                mockStorageWriter.Setup(writer => writer.SaveCommandAsync(It.IsAny<string>()))
                    .Callback<string>(command => savedCommands.Add(command));

                // запись команд
                foreach (string command in commands)
                {
                    mockStorageWriter.Object.SaveCommandAsync(command);
                }

                // Сравнение
                Assert.Equal(commands, savedCommands);
            }
        
        
        
        [Fact]
        public async Task TestNewFigureCheckerExpectedTriangleWithMoq()
        {
            // Создаем мок для интерфейса IStorageWriter
            var mockStorageWriter = new Mock<IStorageWriter>();

            // Список для имитации сохраненных фигур (вместо файла)
            var savedFigures = new List<string>();

            // Настраиваем мок для записи фигур в список
            mockStorageWriter.Setup(writer => writer.SaveCommandAsync(It.IsAny<string>()))
                .Callback<string>(figure => savedFigures.Add(figure));

            // Создаем необходимые объекты
            var turtle = new Turtle();
            var moveCommand = new MoveCommand();
            var angleCommand = new AngleCommand();
            var checker = new NewFigureChecker(turtle, mockStorageWriter.Object);

            // Ожидаемая фигура - треугольник
            var expectedFigure = "треугольник";

            // Выполняем команды для создания треугольника
            for (int i = 1; i <= 3; i++)
            {
                moveCommand.Execute(turtle, "10"); // Движение на 10 единиц
                angleCommand.Execute(turtle, "120"); // Поворот на 120 градусов
                await checker.Check(); // Проверяем, образовалась ли фигура
            }

            // Проверяем, что сохраненная фигура — треугольник
            Assert.Contains(expectedFigure, savedFigures[0].Split(' ')[0]);
        }

        [Fact]
        public async Task TestNewFigureCheckerExpectedSquareWithMoq()
        {
            // Создаем мок для интерфейса IStorageWriter
            var mockStorageWriter = new Mock<IStorageWriter>();

            // Список для имитации сохраненных фигур (вместо файла)
            var savedFigures = new List<string>();

            // Настраиваем мок для записи фигур в список
            mockStorageWriter.Setup(writer => writer.SaveCommandAsync(It.IsAny<string>()))
                .Callback<string>(figure => savedFigures.Add(figure));

            // Создаем необходимые объекты
            var turtle = new Turtle();
            var moveCommand = new MoveCommand();
            var angleCommand = new AngleCommand();
            var checker = new NewFigureChecker(turtle, mockStorageWriter.Object);

            // Ожидаемая фигура - треугольник
            var expectedFigure = "квадрат";

            // Выполняем команды для создания треугольника
            for (int i = 1; i <= 4; i++)
            {
                moveCommand.Execute(turtle, "10"); // Движение на 10 единиц
                angleCommand.Execute(turtle, "90"); // Поворот на 120 градусов
                await checker.Check(); // Проверяем, образовалась ли фигура
            }

            // Проверяем, что сохраненная фигура — треугольник
            Assert.Contains(expectedFigure, savedFigures[0].Split(' ')[0]);
        }

        [Fact]
        public async Task TestNewFigureCheckerExpectedPentagonWithMoq()
        {
            // Создаем мок для интерфейса IStorageWriter
            var mockStorageWriter = new Mock<IStorageWriter>();

            // Список для имитации сохраненных фигур (вместо файла)
            var savedFigures = new List<string>();

            // Настраиваем мок для записи фигур в список
            mockStorageWriter.Setup(writer => writer.SaveCommandAsync(It.IsAny<string>()))
                .Callback<string>(figure => savedFigures.Add(figure));

            // Создаем необходимые объекты
            var turtle = new Turtle();
            var moveCommand = new MoveCommand();
            var angleCommand = new AngleCommand();
            var checker = new NewFigureChecker(turtle, mockStorageWriter.Object);

            // Ожидаемая фигура - треугольник
            var expectedFigure = "пятиугольник";

            // Выполняем команды для создания треугольника
            for (int i = 1; i <= 5; i++)
            {
                moveCommand.Execute(turtle, "10"); // Движение на 10 единиц
                angleCommand.Execute(turtle, "72"); // Поворот на 120 градусов
                await checker.Check(); // Проверяем, образовалась ли фигура
            }

            // Проверяем, что сохраненная фигура — треугольник
            Assert.Contains(expectedFigure, savedFigures[0].Split(' ')[0]);
        }



        [Fact]
        public async Task TestFigureCoords()
        {
            // Создаем мок для интерфейса IStorageWriter
            var mockStorageWriter = new Mock<IStorageWriter>();

            // Список для имитации сохраненных данных (вместо файла)
            var savedFigures = new List<string>();

            // Настраиваем мок для записи данных в список
            mockStorageWriter.Setup(writer => writer.SaveCommandAsync(It.IsAny<string>()))
                .Callback<string>(figure => savedFigures.Add(figure));

            // Создаем реальные объекты Turtle, MoveCommand и AngleCommand
            var turtle = new Turtle();
            var moveCommand = new MoveCommand();
            var angleCommand = new AngleCommand();

            // Создаем объект NewFigureChecker, передавая реального Turtle и мок IStorageWriter
            var checker = new NewFigureChecker(turtle, mockStorageWriter.Object);

            // Ожидаемое значение координат
            var expectedCoords = "{(0;0)(0;10)(8,66;5)(0;-0)}";

            // Выполняем команды для перемещения черепашки и проверки координат
            moveCommand.Execute(turtle, "10");
            await checker.Check();
            angleCommand.Execute(turtle, "120");
            await checker.Check();
            moveCommand.Execute(turtle, "10");
            await checker.Check();
            angleCommand.Execute(turtle, "120");
            await checker.Check();
            moveCommand.Execute(turtle, "10");
            await checker.Check();

            // Проверяем, что сохраненная строка соответствует ожидаемым координатам
            Assert.Contains(expectedCoords, savedFigures[0].Split(' ')[1]);
        }


    }
}