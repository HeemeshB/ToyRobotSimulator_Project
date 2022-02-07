using ToyRobotSimulator_Project.Logic.CommandLogic;
using ToyRobotSimulator_Project.Logic.Verification;
using ToyRobotSimulator_Project.Models;

namespace ToyRobotSimulator_Project
{
    /// <summary>
    /// Main loop of the program which retrieves, verify and executes user input
    /// </summary>
    public class Start
    {
        private readonly IVerification _verificationService;
        private readonly IRunCommand _runCommand;

        public Start(IVerification verificationService, IRunCommand runCommand)
        {
            _verificationService = verificationService;
            _runCommand = runCommand;
        }

        public void Run()
        {
            Console.WriteLine("Toy Robot Simulator");

            var table = new TableTop(5, 5);
            var toyRobot = new ToyRobot();

            while (true)
            {
                Console.WriteLine("Please enter a command");
                var inputCommand = Console.ReadLine();
                
                if (string.IsNullOrEmpty(inputCommand))
                {
                    continue;
                }

                var fullCommand = _verificationService.VerifyCommand(inputCommand);

                _runCommand.Execute(fullCommand, toyRobot, table);
            }
        }
    }
}