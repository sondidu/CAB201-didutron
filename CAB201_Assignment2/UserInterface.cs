namespace Didutron
{
    public class UserInterface
    {
        public static void Help(string[] args)
        {
            ArgsCount.CheckArgsCount(args, ArgsCount.NoArgs);

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

        public static void Help()
        {
            Help([]);
        }

        public static void Exit(string[] args)
        {
            ArgsCount.CheckArgsCount(args, ArgsCount.NoArgs);
            Console.WriteLine("Thank you for using Didutron.");
        }

        public static void Exit()
        {
            Exit([]);
        }
    }
}
