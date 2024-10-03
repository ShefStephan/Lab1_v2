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

        //�������� ������
        [Theory] 
        [InlineData("5", 0, 5)]
        [InlineData("7", 0, 7)]
        [InlineData("10", 0, 10)]
        public void TestMoveCommand(string str, double expX, double expY)
        {
  
            Turtle turtle = new Turtle();
            MoveCommand moveCommand = new MoveCommand();

            string command = str;
            double expectedX = expX;
            double expectedY = expY;

            //��������
            moveCommand.Execute(turtle, command);
            double actualX = turtle.GetCoordX();
            double actualY = turtle.GetCoordY();

            //��������
            Assert.Equal(expectedX, actualX);
            Assert.Equal (expectedY, actualY);

        }

        [Fact]
        public void TestMoveCommandWithRandomData()
        {
            // �������������
            Random rnd = new Random();
            Turtle turtle = new Turtle();
            MoveCommand moveCommand = new MoveCommand();

            //������
            string command = rnd.Next(100).ToString();
            double expectedY = double.Parse(command);

            //��������
            moveCommand.Execute(turtle, command);

            //��������
            Assert.Equal(0, turtle.GetCoordX());
            Assert.Equal(expectedY, turtle.GetCoordY());

        }


        [Fact]
        public void TestAngleCommand()
        {
            //�������� ������
            Turtle turtle = new Turtle();
            AngleCommand angleCommand = new AngleCommand();
            string command = "90";
            double expected = 90;
            

            //��������
            angleCommand.Execute(turtle, command);
            double actual = turtle.GetAngle();

            //��������
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestPenUpCommand()
        {
            //�������� ������
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
            //�������� ������
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
            //�������� ������
            Turtle turtle = new Turtle();
            SetColorCommand setColorCommand = new SetColorCommand();
            string command = "red";
            string expected = "red";


            //��������
            setColorCommand.Execute(turtle, command);
            string actual = turtle.GetColor();

            //��������
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestSetWidthCommand()
        {
            //�������� ������
            Turtle turtle = new Turtle();
            SetWidthCommand setWidthCommand = new SetWidthCommand();
            string command = "1";
            double expected = 1;


            //��������
            setWidthCommand.Execute(turtle, command);
            double actual = turtle.GetWidth();

            //��������
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestHistoryCommand()
        {
            //�������� ������
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

            string expected = "�����������";

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