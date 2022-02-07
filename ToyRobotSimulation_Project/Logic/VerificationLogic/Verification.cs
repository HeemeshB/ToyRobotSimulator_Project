using ToyRobotSimulator_Project.Enums;
using ToyRobotSimulator_Project.Models;

namespace ToyRobotSimulator_Project.Logic.Verification
{
    /// <summary>
    /// Checks if input string is a valid command and in the correct format
    /// </summary>
    public class Verification : IVerification
    {
        public Command VerifyCommand(string command)
        {
            string[] splitCommand = command.Split(' ');

            return new Command()
            {
                CommandOption = VerifyCommandOption(splitCommand[0]),
                Position = splitCommand.Length > 1 ? VerifyCommandPosition(splitCommand[1]) : null
            };
        }

        private CommandOption VerifyCommandOption(string command)
        {
            CommandOption commandOption;

            try
            {
                commandOption = (CommandOption)Enum.Parse(typeof(CommandOption), command, true);
            }
            catch (Exception ex)
            {
                throw new Exception($"Invalid command: {ex.Message}");
            }

            return commandOption;
        }

        private Position? VerifyCommandPosition(string positions)
        {
            string[] splitPosition = positions.Split(',');

            if (splitPosition.Length != 3)
            {
                throw new Exception("Invalid position format");
            }

            int positionX;
            int positionY;

            try
            {
                positionX = int.Parse(splitPosition[0]);
                positionY = int.Parse(splitPosition[1]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new Position()
            {
                PositionX = positionX,
                PositionY = positionY,
                Direction = VerifyCommandDirection(splitPosition[2])
            };
        }

        private CardinalDirection VerifyCommandDirection(string direction)
        {
            CardinalDirection cardinalDirection;

            try
            {
                cardinalDirection = (CardinalDirection)Enum.Parse(typeof(CardinalDirection), direction, true);
            }
            catch (Exception ex)
            {
                throw new Exception($"Invalid direction {ex.Message}");
            }

            return cardinalDirection;
        }
    }
}
