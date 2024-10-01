using Lab1_v2.Commands;
using Lab1_v2.Storage;
using Lab1_v2.TurtleObject;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject1
{
    public class TurtleCommandTest
    {

        //TODO expected должно быть рандомным значением
        [Fact] //TODO почитать про [Theory]
        public void TestMoveCommand()
        {
            //тестовые данные
            Turtle turtle = new Turtle();
            MoveCommand moveCommand = new MoveCommand();
            string command = "5";
            double expected_x = 0;
            double expected_y = 5;

            //действие
            moveCommand.Execute(command, turtle);
            double actual_x = turtle.GetCoordX();
            double actual_y = turtle.GetCoordY();

            //проверка
            Assert.Equal(expected_x, actual_x);
            Assert.Equal (expected_y, actual_y);

        }

        [Fact]
        public void TestAngleCommand()
        {
            //тестовые данные
            Turtle turtle = new Turtle();
            AngleCommand angleCommand = new AngleCommand();
            string command = "90";
            double expected = 90;
            

            //действие
            angleCommand.Execute(turtle, command);
            double actual = turtle.GetAngle();

            //проверка
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestPenUpCommand()
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
        public void TestPenDownCommand()
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
        public void TestSetColorCommand()
        {
            //тестовые данные
            Turtle turtle = new Turtle();
            SetColorCommand setColorCommand = new SetColorCommand();
            string command = "red";
            string expected = "red";


            //действие
            setColorCommand.Execute(command, turtle);
            string actual = turtle.GetColor();

            //проверка
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestSetWidthCommand()
        {
            //тестовые данные
            Turtle turtle = new Turtle();
            SetWidthCommand setWidthCommand = new SetWidthCommand();
            string command = "1";
            double expected = 1;


            //действие
            setWidthCommand.Execute(turtle, command);
            double actual = turtle.GetWidth();

            //проверка
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestHistoryCommand()
        {
            //тестовые данные
            string filePath = "TestHistoryCommands3.txt";
            StorageWriter storageWriter = new StorageWriter(filePath);
            string[] expected = { "move 5", "angle 90", "penup"};
  
            string command_1 = "move 5";
            string command_2 = "angle 90";
            string command_3 = "penup";

            storageWriter.SaveCommand(command_1);
            storageWriter.SaveCommand(command_2);
            storageWriter.SaveCommand(command_3);

            string[] actual = File.ReadAllLines(filePath);
            

            Assert.Equal(expected, actual);
            
            
        }

        [Fact]
        public void TestNewFigureChecker()
        {
            string filePathFigures = "TestForFiguresChecker1.txt";

            StorageWriter storageWriterForFigures = new StorageWriter(filePathFigures);
            Turtle turtle = new Turtle();
            MoveCommand moveCommand = new MoveCommand();
            AngleCommand angleCommand = new AngleCommand();
            NewFigureChecker checker = new NewFigureChecker(turtle, storageWriterForFigures);

            string expected = "треугольник";

            moveCommand.Execute(turtle, "10");
            checker.Check();
            angleCommand.Execute(turtle, "120");
            checker.Check();
            moveCommand.Execute(turtle, "10");
            checker.Check();
            angleCommand.Execute(turtle, "120");
            checker.Check();
            moveCommand.Execute(turtle, "10");
            checker.Check();

            string actual = File.ReadAllLines(filePathFigures)[0];

            Assert.Contains(expected, actual);

        }

        //[Fact]
        //public void TestFigureCooerds()
        //{
        //    string filePathFigures = "TestForFiguresChecker2.txt";
        //    StorageWriter storageWriterForFigures = new StorageWriter(filePathFigures);
        //    Turtle turtle = new Turtle();
        //    MoveCommand moveCommand = new MoveCommand();
        //    AngleCommand angleCommand = new AngleCommand();
        //    NewFigureChecker checker = new NewFigureChecker(turtle, storageWriterForFigures);
        //    string expected = "{(0;0)(0;10)(8,66;5)(0;-0)}";

        //    moveCommand.Execute("10", turtle);
        //    checker.Check();
        //    angleCommand.Execute("120", turtle);
        //    checker.Check();
        //    moveCommand.Execute("10", turtle);
        //    checker.Check();
        //    angleCommand.Execute("120", turtle);
        //    checker.Check();
        //    moveCommand.Execute("10", turtle);
        //    checker.Check();

        //    string actual = File.ReadAllLines(filePathFigures)[0];

        //    Assert.Contains(expected, actual);
        //}


    }
}