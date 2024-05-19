using CommandTree;
using ConstantsAndHelpers;
namespace Didutron
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid();
            var guardFactory = new ObstacleFactory(grid, ObstacleType.Guard);
            var fenceFactory = new ObstacleFactory(grid, ObstacleType.Fence);
            var sensorFactory = new ObstacleFactory(grid, ObstacleType.Sensor);
            var cameraFactory = new ObstacleFactory(grid, ObstacleType.Camera);

            var commandChildren = new Dictionary<string, Command>
            {
                { CommandKey.Add, new Command(new Dictionary<string, Command>
                    {
                        { CommandKey.Guard, new Command(guardFactory.AddToGrid) },
                        { CommandKey.Fence, new Command(fenceFactory.AddToGrid) },
                        { CommandKey.Sensor, new Command(sensorFactory.AddToGrid) },
                        { CommandKey.Camera, new Command(cameraFactory.AddToGrid) }
                    },
                    invalidCommandKeyMsg: ErrorMessages.InvalidObstacle,
                    unspecifiedCommandKeyMsg: ErrorMessages.UnspecifiedObstacle)
                },
                { CommandKey.Check, new Command(grid.Check) },
                { CommandKey.Map, new Command(grid.Map) },
                { CommandKey.Path, new Command(grid.Path) },
                { CommandKey.Help, new Command(UserInterface.Help) },
                { CommandKey.Exit, new Command(UserInterface.Exit) }
            };
            var rootCommand = new Command(commandChildren, ErrorMessages.InvalidOption);
            var runner = new Runner(rootCommand);

            UserInterface.Welcome();
            UserInterface.Help();

            string? input = "";
            while (input != CommandKey.Exit)
            {
                Console.WriteLine(SuccessMessages.AskForCommand);
                input = Console.ReadLine();
                bool noErrors = runner.TryRun(input, out string message);
                if (!noErrors)
                {
                    Console.WriteLine(message);
                }
            }
        }
    }
}
