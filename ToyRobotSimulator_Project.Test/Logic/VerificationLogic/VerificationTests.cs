using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToyRobotSimulator_Project.Enums;
using ToyRobotSimulator_Project.Logic.Verification;

namespace ToyRobotSimulator_Project.Test.Logic.VerificationLogic
{
    [TestClass]
    public class VerificationTests
    {
        [TestMethod]
        [DataRow("REPORT")]
        [DataRow("report")]
        [DataRow("Report")]
        public void VerifyReportCommandOption_ReturnsExpectedCommandOption(string command)
        {
            var verification = new Verification();

            var verifiedCommand = verification.VerifyCommand(command);

            Assert.AreEqual(CommandOption.Report, verifiedCommand.CommandOption);
        }

        [TestMethod]
        [DataRow("MOVE")]
        [DataRow("move")]
        [DataRow("Move")]
        public void VerifyMoveCommandOption_ReturnsExpectedCommandOption(string command)
        {
            var verification = new Verification();

            var verifiedCommand = verification.VerifyCommand(command);

            Assert.AreEqual(CommandOption.Move, verifiedCommand.CommandOption);
        }

        [TestMethod]
        [DataRow("LEFT")]
        [DataRow("left")]
        [DataRow("Left")]
        public void VerifyLeftCommandOption_ReturnsExpectedCommandOption(string command)
        {
            var verification = new Verification();

            var verifiedCommand = verification.VerifyCommand(command);

            Assert.AreEqual(CommandOption.Left, verifiedCommand.CommandOption);
        }

        [TestMethod]
        [DataRow("RIGHT")]
        [DataRow("right")]
        [DataRow("Right")]
        public void VerifyRightCommandOption_ReturnsExpectedCommandOption(string command)
        {
            var verification = new Verification();

            var verifiedCommand = verification.VerifyCommand(command);

            Assert.AreEqual(CommandOption.Right, verifiedCommand.CommandOption);
        }

        [TestMethod]
        [DataRow("PLACE 1,1,NORTH")]
        [DataRow("place 1,1,NORTH")]
        [DataRow("Place 1,1,NORTH")]
        public void VerifyPlaceCommandOption_ReturnsExpectedCommandOption(string command)
        {
            var verification = new Verification();

            var verifiedCommand = verification.VerifyCommand(command);

            Assert.AreEqual(CommandOption.Place, verifiedCommand.CommandOption);
        }

        [TestMethod]
        [DataRow("PLACE 1,2,NORTH")]
        [DataRow("PLACE 1,2,north")]
        [DataRow("PLACE 1,2,North")]
        public void VerifyNorthPosition_ReturnsExpectedPosition(string command)
        {
            var verification = new Verification();

            var verifiedCommand = verification.VerifyCommand(command);

            Assert.AreEqual(1, verifiedCommand.Position.PositionX);
            Assert.AreEqual(2, verifiedCommand.Position.PositionY);
            Assert.AreEqual(CardinalDirection.North, verifiedCommand.Position.Direction);
        }

        [TestMethod]
        [DataRow("PLACE 1,2,EAST")]
        [DataRow("PLACE 1,2,east")]
        [DataRow("PLACE 1,2,East")]
        public void VerifyEastPosition_ReturnsExpectedPosition(string command)
        {
            var verification = new Verification();

            var verifiedCommand = verification.VerifyCommand(command);

            Assert.AreEqual(1, verifiedCommand.Position.PositionX);
            Assert.AreEqual(2, verifiedCommand.Position.PositionY);
            Assert.AreEqual(CardinalDirection.East, verifiedCommand.Position.Direction);
        }

        [TestMethod]
        [DataRow("PLACE 1,2,SOUTH")]
        [DataRow("PLACE 1,2,south")]
        [DataRow("PLACE 1,2,South")]
        public void VerifySouthPosition_ReturnsExpectedPosition(string command)
        {
            var verification = new Verification();

            var verifiedCommand = verification.VerifyCommand(command);

            Assert.AreEqual(1, verifiedCommand.Position.PositionX);
            Assert.AreEqual(2, verifiedCommand.Position.PositionY);
            Assert.AreEqual(CardinalDirection.South, verifiedCommand.Position.Direction);
        }

        [TestMethod]
        [DataRow("PLACE 1,2,WEST")]
        [DataRow("PLACE 1,2,west")]
        [DataRow("PLACE 1,2,West")]
        public void VerifyWestPosition_ReturnsExpectedPosition(string command)
        {
            var verification = new Verification();

            var verifiedCommand = verification.VerifyCommand(command);

            Assert.AreEqual(1, verifiedCommand.Position.PositionX);
            Assert.AreEqual(2, verifiedCommand.Position.PositionY);
            Assert.AreEqual(CardinalDirection.West, verifiedCommand.Position.Direction);
        }

        [TestMethod]
        [DataRow("MOV")]
        [DataRow("MOVEMENT")]
        [ExpectedException(typeof(Exception))]
        public void VerifyMisspellingCommandOption_ReturnsException(string command)
        {
            var verification = new Verification();

            verification.VerifyCommand(command);

        }

        [TestMethod]
        [DataRow("PLACE 1,1,1,NORTH")]
        [DataRow("PLACE 1,NORTH")]
        [ExpectedException(typeof(Exception))]
        public void VerifyPositionFormat_ReturnsException(string command)
        {
            var verification = new Verification();
            
            verification.VerifyCommand(command);
        }

        [TestMethod]
        [DataRow("PLACE 1,1,NOR")]
        [ExpectedException(typeof(Exception))]
        public void VerifyMisspellingCardinalDirection_ReturnsException(string command)
        {
            var verification = new Verification();

            verification.VerifyCommand(command);
        }
    }
}
