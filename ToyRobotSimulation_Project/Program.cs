using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToyRobotSimulator_Project.Logic.CommandLogic;
using ToyRobotSimulator_Project.Logic.Verification;

namespace ToyRobotSimulator_Project
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Configure services
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((conext, services) =>
                {
                    services.AddSingleton<IVerification, Verification>();
                    services.AddSingleton<IRunCommand, RunCommand>();
                })
                .Build();

            var services = ActivatorUtilities.CreateInstance<Start>(host.Services);
            services.Run();

        }
    }
}