using ToyRobotSimulator_Project.Enums;
using ToyRobotSimulator_Project.Models;

namespace ToyRobotSimulator_Project.Logic.CommandLogic
{
    public class RunCommand : IRunCommand
    {
        public void Execute(Command fullCommand, ToyRobot toyRobot, TableTop tableTop)
        {
            switch (fullCommand.CommandOption)
            {
                case CommandOption.Place:

                    var isOnTableTop = IsOnTableTop(fullCommand.Position, tableTop);

                    if (!IsRobotPlaced(toyRobot.Position) && isOnTableTop)
                    {
                        toyRobot.Position = new Position();
                    }

                    if (isOnTableTop)
                    {
                        toyRobot.Position.PositionX = fullCommand.Position.PositionX;
                        toyRobot.Position.PositionY = fullCommand.Position.PositionY;
                        toyRobot.Position.Direction = fullCommand.Position.Direction;
                    }
                    break;

                case CommandOption.Move:

                    if (!IsRobotPlaced(toyRobot.Position))
                    {
                        return;
                    }

                    var tempPosition = MoveRobot(toyRobot.Position);

                    if (IsOnTableTop(tempPosition, tableTop))
                    {
                        toyRobot.Position.PositionX = tempPosition.PositionX;
                        toyRobot.Position.PositionY = tempPosition.PositionY;
                    }
                    break;

                case CommandOption.Left:

                    if (!IsRobotPlaced(toyRobot.Position))
                    {
                        return;
                    }

                    toyRobot.Position.Direction = RotateRobotLeft(toyRobot.Position.Direction);
                    break;

                case CommandOption.Right:

                    if (!IsRobotPlaced(toyRobot.Position))
                    {
                        return;
                    }

                    toyRobot.Position.Direction = RotateRobotRight(toyRobot.Position.Direction);
                    break;

                case CommandOption.Report:

                    if (!IsRobotPlaced(toyRobot.Position))
                    {
                        return;
                    }

                    Report($"{toyRobot.Position.PositionX},{toyRobot.Position.PositionY},{toyRobot.Position.Direction}");
                    break;
            }
        }

        private CardinalDirection RotateRobotLeft(CardinalDirection cardinalDirection)
        {
            cardinalDirection--;
            if (cardinalDirection < Enum.GetValues(typeof(CardinalDirection)).Cast<CardinalDirection>().Min())
            {
                cardinalDirection = Enum.GetValues(typeof(CardinalDirection)).Cast<CardinalDirection>().Max();
            }

            return cardinalDirection;
        }

        private CardinalDirection RotateRobotRight(CardinalDirection cardinalDirection)
        {
            cardinalDirection++;
            if (cardinalDirection > Enum.GetValues(typeof(CardinalDirection)).Cast<CardinalDirection>().Max())
            {
                cardinalDirection = Enum.GetValues(typeof(CardinalDirection)).Cast<CardinalDirection>().Min();
            }

            return cardinalDirection;
        }


        private Position MoveRobot(Position position)
        {
            var tempPosition = new Position()
            {
                PositionX = position.PositionX,
                PositionY = position.PositionY
            };

            if (position.Direction == CardinalDirection.North)
            {
                tempPosition.PositionX++;
            }
            else if (position.Direction == CardinalDirection.South)
            {
                tempPosition.PositionX--;
            }
            else if (position.Direction == CardinalDirection.East)
            {
                tempPosition.PositionY++;
            }
            else if (position.Direction == CardinalDirection.West)
            {
                tempPosition.PositionY--;
            }

            return tempPosition;
        }

        private void Report(string message)
        {
            Console.WriteLine(message);
        }

        private bool IsRobotPlaced(Position position)
        {
            return position != null ? true : false; 
        }

        private bool IsOnTableTop(Position position, TableTop tableTop)
        {
            if (position.PositionX > tableTop.TableSizeX
                || position.PositionX < tableTop.TableSizeStartX
                || position.PositionY > tableTop.TableSizeY
                || position.PositionY < tableTop.TableSizeStartY)
            {
                return false;
            }

            return true;
        }
    }
}
