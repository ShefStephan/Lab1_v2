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

            //��������
            moveCommand.Execute(turtle, command);
            double actualX = turtle.GetCoordX();
            double actualY = turtle.GetCoordY();

            //��������
            Assert.Equal(expectedX, actualX);
            Assert.Equal(expectedY, actualY);

        }

        [Fact]
        public void TestMoveCommandWithRandomData()
        {
            // �������������
            Random rnd = new Random();
            Turtle turtle = new Turtle();
            MoveCommand moveCommand = new MoveCommand();

            //������
            string command = rnd.Next(1000).ToString();
            double expectedY = double.Parse(command);

            //��������
            moveCommand.Execute(turtle, command);

            //��������
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
            //�������� ������
            Turtle turtle = new Turtle();
            AngleCommand angleCommand = new AngleCommand();
            string command = str;
            double expected = exp;


            //��������
            angleCommand.Execute(turtle, command);
            double actual = turtle.GetAngle();

            //��������
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestPenUpCommandResult()
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
        public void TestPenDownCommandResult()
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
        public void TestSetColorCommandResult()
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
        public void TestSetWidthCommandWithRandomData()
        {
            //�������� ������
            Random rnd = new Random();
            Turtle turtle = new Turtle();
            SetWidthCommand setWidthCommand = new SetWidthCommand();
            string command = rnd.Next(1000).ToString();
            double expected = 1;


            //��������
            setWidthCommand.Execute(turtle, command);
            double actual = turtle.GetWidth();

            //��������
            Assert.Equal(expected, actual);

        }



        [Theory]
        [InlineData("move 5", "angle 90", "penup")]
        [InlineData("pedown", "penup", "move 5")]
        [InlineData("angle 78", "history", "width 10")]
        [InlineData("pendown", "color red", "move -5")]
        [InlineData("move 33", "penup", "history")]
        public void TestHistoryCommandWithInlineData(params string[] commands)
        {
            //�������� ������
            string filePath = "TestHistoryCommands5.txt";
            StorageWriter storageWriter = new StorageWriter(filePath);
            string[] expected = commands;

            foreach (string command in commands)
            {
                storageWriter.SaveCommand(command);
            }
            string[] actual = File.ReadAllLines(filePath);


            Assert.Equal(expected, actual);
            storageWriter.ClearFile();


        }

        [Fact]
        public void TestNewFigureCheckerExpectedTriangle()
        {
            string filePathFigures = "TestForFiguresCheckerTriangle.txt";

            StorageWriter storageWriterForFigures = new StorageWriter(filePathFigures);
            Turtle turtle = new Turtle();
            MoveCommand moveCommand = new MoveCommand();
            AngleCommand angleCommand = new AngleCommand();
            NewFigureChecker checker = new NewFigureChecker(turtle, storageWriterForFigures);

            string expected = "�����������";

            for (int i = 1; i <= 3; i++)
            {
                moveCommand.Execute(turtle, "10");
                angleCommand.Execute(turtle, "120");
                checker.Check();
            }

            string actual = File.ReadAllLines(filePathFigures)[0];

            Assert.Contains(expected, actual);
            storageWriterForFigures.ClearFile();

        }

        [Fact]
        public void TestNewFigureCheckerExpectedSquare()
        {
            string filePathFigures = "TestForFiguresCheckerSquare.txt";

            StorageWriter storageWriterForFigures = new StorageWriter(filePathFigures);
            Turtle turtle = new Turtle();
            MoveCommand moveCommand = new MoveCommand();
            AngleCommand angleCommand = new AngleCommand();
            NewFigureChecker checker = new NewFigureChecker(turtle, storageWriterForFigures);

            string expected = "�������";

            for (int i = 1; i <= 4; i++)
            {
                moveCommand.Execute(turtle, "10");
                angleCommand.Execute(turtle, "90");
                checker.Check();
            }

            string actual = File.ReadAllLines(filePathFigures)[0];

            Assert.Contains(expected, actual);
            storageWriterForFigures.ClearFile();

        }

        [Fact]
        public void TestNewFigureCheckerExpectedPentagon()
        {
            string filePathFigures = "TestForFiguresCheckerPntagon.txt";

            StorageWriter storageWriterForFigures = new StorageWriter(filePathFigures);
            Turtle turtle = new Turtle();
            MoveCommand moveCommand = new MoveCommand();
            AngleCommand angleCommand = new AngleCommand();
            NewFigureChecker checker = new NewFigureChecker(turtle, storageWriterForFigures);

            string expected = "������������";

            for (int i = 1; i <= 5; i++)
            {
                moveCommand.Execute(turtle, "10");
                angleCommand.Execute(turtle, "72");
                checker.Check();
            }

            string actual = File.ReadAllLines(filePathFigures)[0];

            Assert.Contains(expected, actual);
            storageWriterForFigures.ClearFile();
        }



        [Fact]
        public void TestFigureCoords()
        {
            string filePathFigures = "TestForFiguresChecker2.txt";
            StorageWriter storageWriterForFigures = new StorageWriter(filePathFigures);
            Turtle turtle = new Turtle();
            MoveCommand moveCommand = new MoveCommand();
            AngleCommand angleCommand = new AngleCommand();
            NewFigureChecker checker = new NewFigureChecker(turtle, storageWriterForFigures);
            string expected = "{(0;0)(0;10)(8,66;5)(0;-0)}";

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


    }
}