using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator_Project.Enums;
using ToyRobotSimulator_Project.Logic.CommandLogic;
using ToyRobotSimulator_Project.Models;

namespace ToyRobotSimulator_Project.Test.Logic.CommandLogic
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void VerifyRobotPlacement_ReturnsExpectedPosition()
        {
            var tableTop = new TableTop(5, 5);
            var toyRobot = new ToyRobot();
            var fullCommand = new Command()
            {
                CommandOption = CommandOption.Place,
                Position = new Position()
                {
                    PositionX = 1,
                    PositionY = 2,
                    Direction = CardinalDirection.North
                }
            };

            var runCommand = new RunCommand();
            runCommand.Execute(fullCommand, toyRobot, tableTop);

            Assert.AreEqual(1, toyRobot.Position.PositionX);
            Assert.AreEqual(2, toyRobot.Position.PositionY);
            Assert.AreEqual(CardinalDirection.North, toyRobot.Position.Direction);
        }

        [TestMethod]
        public void VerifyRobotOutOfRangePlacement_ReturnsExpectedNullPosition()
        {
            var tableTop = new TableTop(5, 5);
            var toyRobot = new ToyRobot();
            var fullCommand = new Command()
            {
                CommandOption = CommandOption.Place,
                Position = new Position()
                {
                    PositionX = 8,
                    PositionY = 2,
                    Direction = CardinalDirection.North
                }
            };

            var runCommand = new RunCommand();
            runCommand.Execute(fullCommand, toyRobot, tableTop);

            Assert.IsNull(toyRobot.Position);
        }

        [TestMethod]
        public void VerifyRobotMovement_ReturnsExpectedPosition()
        {
            var tableTop = new TableTop(5, 5);
            var toyRobot = new ToyRobot()
            {
                Position = new Position()
                {
                    PositionX = 2,
                    PositionY = 2,
                    Direction = CardinalDirection.East
                }
            };
            var fullCommand = new Command()
            {
                CommandOption = CommandOption.Move
            };

            var runCommand = new RunCommand();
            runCommand.Execute(fullCommand, toyRobot, tableTop);

            Assert.AreEqual(2, toyRobot.Position.PositionX);
            Assert.AreEqual(3, toyRobot.Position.PositionY);
            Assert.AreEqual(CardinalDirection.East, toyRobot.Position.Direction);
        }

        [TestMethod]
        public void VerifyRobotOutOfRangeMovement_ReturnsExpectedSamePosition()
        {
            var tableTop = new TableTop(5, 5);
            var toyRobot = new ToyRobot()
            {
                Position = new Position()
                {
                    PositionX = 5,
                    PositionY = 2,
                    Direction = CardinalDirection.North
                }
            };
            var fullCommand = new Command()
            {
                CommandOption = CommandOption.Move
            };

            var runCommand = new RunCommand();
            runCommand.Execute(fullCommand, toyRobot, tableTop);

            Assert.AreEqual(5, toyRobot.Position.PositionX);
            Assert.AreEqual(2, toyRobot.Position.PositionY);
            Assert.AreEqual(CardinalDirection.North, toyRobot.Position.Direction);
        }

        [TestMethod]
        public void VerifyRobotLeftRotation_ReturnsExpectedPosition()
        {
            var tableTop = new TableTop(5, 5);
            var toyRobot = new ToyRobot()
            {
                Position = new Position()
                {
                    PositionX = 1,
                    PositionY = 2,
                    Direction = CardinalDirection.North
                }
            };
            var fullCommand = new Command()
            {
                CommandOption = CommandOption.Left
            };

            var runCommand = new RunCommand();
            runCommand.Execute(fullCommand, toyRobot, tableTop);

            Assert.AreEqual(1, toyRobot.Position.PositionX);
            Assert.AreEqual(2, toyRobot.Position.PositionY);
            Assert.AreEqual(CardinalDirection.West, toyRobot.Position.Direction);
        }

        [TestMethod]
        public void VerifyRobotRightRotation_ReturnsExpectedPosition()
        {
            var tableTop = new TableTop(5, 5);
            var toyRobot = new ToyRobot()
            {
                Position = new Position()
                {
                    PositionX = 1,
                    PositionY = 2,
                    Direction = CardinalDirection.North
                }
            };
            var fullCommand = new Command()
            {
                CommandOption = CommandOption.Right
            };

            var runCommand = new RunCommand();
            runCommand.Execute(fullCommand, toyRobot, tableTop);

            Assert.AreEqual(1, toyRobot.Position.PositionX);
            Assert.AreEqual(2, toyRobot.Position.PositionY);
            Assert.AreEqual(CardinalDirection.East, toyRobot.Position.Direction);
        }
    }
}