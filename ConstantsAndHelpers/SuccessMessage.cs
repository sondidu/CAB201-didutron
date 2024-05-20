namespace ConstantsAndHelpers
{
    public static class SuccessMessage
    {
        public const string AddedObstacle = "Successfully added {0} obstacle.";
        public const string SafeDirections = "You can safely take any of the following directions:";
        public const string SelectedRegion = "Here is a map of obstacles in the selected region:";
        public const string ThereIsSafePath = "The following path will take you to the objective:";
        public const string DirectionUnitFormat = "Head {0} for {1} {2}.";
        public const string Unit = "klick";
        public const string Exit = "Thank you for using Didutron.";
        public const string Welcome = "Welcome to Didutron Obstacle Avoidance System!\n";
        public const string AskForCommand = "Enter command:";

        public static void PrintMovement(string direction, int count, string format=DirectionUnitFormat, string unit=Unit)
        {
            if (count > 1)
            {
                unit += 's';
            }
            Console.WriteLine(format, direction, count, unit);
        }

        public static string CapitaliseFirstLetter(string word)
        {
            if (word.Length == 0)
            {
                return word;
            }
            return char.ToUpper(word[0]) + word[1..];
        }

        public static void PrintHelp()
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
    }
}
