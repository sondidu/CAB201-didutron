using CommandValidation;
namespace Didutron
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid();
            var guardFactory = new GuardFactory(grid);
            var fenceFactory = new FenceFactory(grid);
            var sensorFactory = new SensorFactory(grid);
            var cameraFactory = new CameraFactory(grid);

            var coordIntArg = new IntArg("Coordinates are not valid integers.");
            var fenceOrientationArg = new StringArg("Orientation must be 'east' or 'north'.", "east", "north");
            var sensorRangeArg = new DoubleArg("Range must be a valid positive number.", true);
            var cameraDirectionArg = new StringArg("Direction must be 'north', 'south', 'east' or 'west'.", "north", "south", "east", "west");
            var mapLengthArg = new IntArg("Width and height must be valid positive integers.", true);
            var agentCoordIntArg = new IntArg("Agent coordinates are not valid integers.");
            var objectiveCoordIntArg = new IntArg("Objective coordinates are not valid integers.");
            var fenceLengthArg = new IntArg("Length must be a valid integer greater than 0.", true);

            var commandsList = new Dictionary<string, Command>
            {
                { "add", new Command(new Dictionary<string, Command>
                    {
                        { "guard", new Command(guardFactory.AddToGrid, coordIntArg, coordIntArg) },
                        { "fence", new Command(fenceFactory.AddToGrid, coordIntArg, coordIntArg, fenceOrientationArg, fenceLengthArg) },
                        { "sensor", new Command(sensorFactory.AddToGrid, coordIntArg, coordIntArg, sensorRangeArg) },
                        { "camera", new Command(cameraFactory.AddToGrid, coordIntArg, coordIntArg,  cameraDirectionArg) }
                    },
                    invalidKeyErrorMsg: "Invalid obstacle type.",
                    noKeyErrorMsg: "You need to specify an obstacle type.")
                },
                { "check", new Command(grid.Check, coordIntArg, coordIntArg) },
                { "map", new Command(grid.Map, coordIntArg, coordIntArg, mapLengthArg, mapLengthArg) },
                { "path", new Command(grid.Path, agentCoordIntArg, agentCoordIntArg, objectiveCoordIntArg, objectiveCoordIntArg) },
                { "help", new Command(UserInterface.Help) },
                { "exit", new Command(UserInterface.Exit) }
            };
            var commands = new Command(commandsList, "Invalid option: {0}\nType 'help' to see a list of commands.");
            var commandValidator = new CommandValidator(commands);

            Console.WriteLine("Welcome to Didutron Obstacle Avoidance System!");
            Console.WriteLine();

            UserInterface.Help();

            string? input = "";
            while (input != "exit")
            {
                Console.WriteLine("Enter command: ");
                input = Console.ReadLine();
                input ??= "";
                commandValidator.CurrentCommand = input;
                commandValidator.TryRun();
            }
        }
    }
}
