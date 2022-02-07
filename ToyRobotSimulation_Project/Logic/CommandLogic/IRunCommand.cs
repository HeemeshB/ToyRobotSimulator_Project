using ToyRobotSimulator_Project.Models;

namespace ToyRobotSimulator_Project.Logic.CommandLogic
{
    public interface IRunCommand
    {
        void Execute(Command fullCommand, ToyRobot toyRobot, TableTop tableTop);
    }
}