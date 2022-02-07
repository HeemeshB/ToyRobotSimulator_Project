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

            // Setup
            var table = new TableTop(5, 5);
            var toyRobot = new ToyRobot();

            while (true)
            {
                // Retrieve user input
                Console.WriteLine("Please enter a command");
                var inputCommand = Console.ReadLine();
                
                if (string.IsNullOrEmpty(inputCommand))
                {
                    continue;
                }

                // Verify user input
                var fullCommand = _verificationService.VerifyCommand(inputCommand);

                // Execute user command
                _runCommand.Execute(fullCommand, toyRobot, table);
            }
        }
    }
}