using ToyRobotSimulator_Project.Models;

namespace ToyRobotSimulator_Project.Logic.Verification
{
    public interface IVerification
    {
        Command VerifyCommand(string command);
    }
}