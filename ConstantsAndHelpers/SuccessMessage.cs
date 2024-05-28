namespace ConstantsAndHelpers
{
    /// <summary>
    /// Provides success messages.
    /// </summary>
    public static class SuccessMessage
    {
        /// <summary>
        /// The format message for successfully adding an obstacle.
        /// The {0} placeholder is replaced with the type of obstacle that was added.
        /// Used in <see cref="GridSystem.ObstacleFactory.AddToGrid(string[])"/>.
        /// </summary>
        public const string AddedObstacleFormat = "Successfully added {0} obstacle.";

        /// <summary>
        /// The message for safe directions.
        /// Used in <see cref="GridSystem.Grid.Check(GridSystem.Coord)"/>.
        /// </summary>
        public const string SafeDirections = "You can safely take any of the following directions:";

        /// <summary>
        /// The message for a selected region.
        /// Used in <see cref="GridSystem.Grid.Map(GridSystem.Coord, GridSystem.Coord)"/>.
        /// </summary>
        public const string SelectedRegion = "Here is a map of obstacles in the selected region:";

        /// <summary>
        /// The message for a safe path.
        /// Used in <see cref="GridSystem.Grid.Path(GridSystem.Coord, GridSystem.Coord)"/>.
        /// </summary>
        public const string ThereIsSafePath = "The following path will take you to the objective:";

        /// <summary>
        /// The format message for displaying the direction, count and unit.
        /// The {0}, {1}, and {2} placeholder is replaced with the direction, count and unit respectively.
        /// </summary>
        public const string DirectionUnitFormat = "Head {0} for {1} {2}.";

        /// <summary>
        /// The unit for coordinates.
        /// Intended to be used in the {2} placeholder of <see cref="DirectionUnitFormat"/>.
        /// </summary>
        public const string Unit = "klick";

        /// <summary>
        /// The message for exiting the <see cref="GridSystem"/>.
        /// </summary>
        public const string Exit = "Thank you for using Didutron.";

        /// <summary>
        /// The message for starting <see cref="GridSystem"/>.
        /// Used in <see cref="GridSystem.Program"/>.
        /// </summary>
        public const string Welcome = "Welcome to Didutron Obstacle Avoidance System!\n";

        /// <summary>
        /// The message to prompt for a command.
        /// Used in <see cref="GridSystem.Program"/>.
        /// </summary>
        public const string AskForCommand = "Enter command:";

        /// <summary>
        /// Prints the available commands using multiple <see cref="Console.WriteLine()"/> calls.
        /// Used in <see cref="GridSystem.MessageDisplay.ListCommands(string[])"/>.
        /// </summary>
        public static void PrintCommands()
        {
            Console.WriteLine("Valid commands are:");
            Console.WriteLine("add guard <x> <y>: registers a guard obstacle");
            Console.WriteLine("add fence <x> <y> <orientation> <length>: registers a fence obstacle. Orientation must be 'east' or 'north'.");
            Console.WriteLine("add sensor <x> <y> <radius>: registers a sensor obstacle");
            Console.WriteLine("add camera <x> <y> <direction>: registers a camera obstacle. Direction must be 'north', 'south', 'east' or 'west'.");
            Console.WriteLine("check <x> <y>: checks whether a location and its surroundings are safe");
            Console.WriteLine("map <x> <y> <width> <height>: draws a text-based map of registered obstacles");
            Console.WriteLine("path <agent x> <agent y> <objective x> <objective y>: finds a path free of obstacles");
            Console.WriteLine("help: displays this help message");
            Console.WriteLine("exit: closes this program");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints a movement message based with the specified direction, count, format and unit.
        /// </summary>
        /// <param name="direction">The direction of the movement.</param>
        /// <param name="count">The number of units moved in the direction.</param>
        /// <param name="format">The format of the message. Default is <see cref="DirectionUnitFormat"/></param>
        /// <param name="unit">The unit of the movement. Default is <see cref="Unit"/></param>
        public static void PrintMovement(string direction, int count, string format=DirectionUnitFormat, string unit=Unit)
        {
            if (count > 1)
            {
                unit += 's';
            }
            Console.WriteLine(format, direction, count, unit);
        }

        /// <summary>
        /// Capitalises the first letter of a string.
        /// </summary>
        /// <param name="word">The string to capitalise.</param>
        /// <returns>The string with the first letter capitalised.</returns>
        public static string CapitaliseFirstLetter(string word)
        {
            if (word.Length == 0)
            {
                return word;
            }
            return char.ToUpper(word[0]) + word[1..];
        }
    }
}
