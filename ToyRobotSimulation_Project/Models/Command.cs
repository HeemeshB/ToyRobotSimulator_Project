using ToyRobotSimulator_Project.Enums;

namespace ToyRobotSimulator_Project.Models
{
    public class Command
    {
        public CommandOption CommandOption { get; set; }
        public Position? Position { get; set; }
    }
}
