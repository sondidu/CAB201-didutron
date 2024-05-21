using CommandTree;
using ConstantsAndHelpers;
namespace GridSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring Grid and ObstacleFactories
            var grid = new Grid();
            var guardFactory = new ObstacleFactory(grid, ObstacleType.Guard);
            var fenceFactory = new ObstacleFactory(grid, ObstacleType.Fence);
            var sensorFactory = new ObstacleFactory(grid, ObstacleType.Sensor);
            var cameraFactory = new ObstacleFactory(grid, ObstacleType.Camera);

            // Defining the command tree
            var commandChildren = new Dictionary<string, Command>
            {
                { CommandKey.Add, new Command
                    (
                        new Dictionary<string, Command>
                        {
                            { CommandKey.Guard, new Command(guardFactory.AddToGrid) },
                            { CommandKey.Fence, new Command(fenceFactory.AddToGrid) },
                            { CommandKey.Sensor, new Command(sensorFactory.AddToGrid) },
                            { CommandKey.Camera, new Command(cameraFactory.AddToGrid) }
                        },
                        invalidCommandKeyMsg: ErrorMessage.InvalidObstacle,
                        unspecifiedCommandKeyMsg: ErrorMessage.UnspecifiedObstacle
                    )
                },
                { CommandKey.Check, new Command(grid.Check) },
                { CommandKey.Map, new Command(grid.Map) },
                { CommandKey.Path, new Command(grid.Path) },
                { CommandKey.Help, new Command(MessageDisplay.ListCommands) },
                { CommandKey.Exit, new Command(MessageDisplay.Exit) }
            };
            var rootCommand = new Command(commandChildren, ErrorMessage.InvalidOption);
            var runner = new Runner(rootCommand);

            // Start with welcome message and list of commands
            MessageDisplay.Welcome();
            MessageDisplay.ListCommands();

            string? input = "";
            while (input != CommandKey.Exit)
            {
                Console.WriteLine(SuccessMessage.AskForCommand);
                input = Console.ReadLine();
                bool noErrors = runner.TryRun(input, out string errorMessage);
                if (!noErrors)
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }
    }
}
