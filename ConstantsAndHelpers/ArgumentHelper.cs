using CustomExceptions;
namespace ConstantsAndHelpers
{
    /// <summary>
    /// Provides constants and helper methods for handling arguments.
    /// </summary>
    public static class ArgumentHelper
    {
        /* Argument lengths */
        /// <summary>
        /// The minimum argument length of every obstacle.
        /// Every obstacle needs at least x and y coordinates, hence where 2 is gotten from.
        /// </summary>
        public const int MinimumObstacleArgsLength = 2;

        /// <summary>
        /// The argument length of a <see cref="GridSystem.Guard"/>.
        /// Guard takes two arguments: x-coordinate and y-coordinate.
        /// </summary>
        public const int GuardArgsLength = 2;

        /// <summary>
        /// The argument length of a <see cref="GridSystem.Fence"/>.
        /// The arguments are: x-coordinate, y-coordinate, orientation and length.
        /// </summary>
        public const int FenceArgsLength = 4;

        /// <summary>
        /// The argument length of a <see cref="GridSystem.Sensor"/>.
        /// The arguments are: x-coordinate, y-coordinate and radius.
        /// </summary>
        public const int SensorArgsLength = 3;

        /// <summary>
        /// The argument length of a <see cref="GridSystem.Camera"/>.
        /// The arguments are: x-coordinate, y-coordinate and direction.
        /// </summary>
        public const int CameraArgsLength = 3;

        /// <summary>
        /// The argument length of <see cref="GridSystem.Grid.Check(string[])"/>.
        /// The arguments are: agent's x-coordinate and y-coordinate.
        /// </summary>
        public const int CheckArgsLength = 2;

        /// <summary>
        /// The argument length of <see cref="GridSystem.Grid.Map(string[])"/>.
        /// The arguments are: the map's bottom-left x-coordinate, bottom-left y-coordinate, width and height.
        /// </summary>
        public const int MapArgsLength = 4;

        /// <summary>
        /// The argument length of <see cref="GridSystem.Grid.Path(string[])"/>.
        /// The arguments are: the agent's x-coordinate, y-coordinate and objective's x-coordinate, y-coordinate.
        /// </summary>
        public const int PathArgsLength = 4;

        /// <summary>
        /// The argument length of methods that don't take any arguments.
        /// Used in <see cref="GridSystem.MessageDisplay.ListCommands(string[])"/> and <see cref="GridSystem.MessageDisplay.Exit(string[])"/>.
        /// </summary>
        public const int NoArgs = 0;

        /* Argument indexes */
        /// <summary>
        /// The index of the x-coordinate in an argument represented as an array of strings.
        /// </summary>
        public const int CoordXIdx = 0;

        /// <summary>
        /// The index of the y-coordinate in an argument represented as an array of strings.
        /// </summary>
        public const int CoordYIdx = 1;

        /// <summary>
        /// The index of a <see cref="GridSystem.Fence"/>'s orientation in an argument represented as an array of strings.
        /// </summary>
        public const int OrientationIdx = 2;

        /// <summary>
        /// The index of a <see cref="GridSystem.Fence"/>'s length in an argument represented as an array of strings.
        /// </summary>
        public const int LengthIdx = 3;

        /// <summary>
        /// The index of a <see cref="GridSystem.Sensor"/>'s radius in an argument represented as an array of strings.
        /// </summary>
        public const int RadiusIdx = 2;

        /// <summary>
        /// The index of a <see cref="GridSystem.Camera"/>'s direction in an argument represented as an array of strings.
        /// </summary>
        public const int DirectionIdx = 2;

        /// <summary>
        /// The index of the target's x-coordinate from <see cref="GridSystem.Grid.Check(string[])"/> in an argument represented as an array of strings.
        /// </summary>
        public const int CheckTargetXIdx = 0;

        /// <summary>
        /// The index of the target's y-coordinate from <see cref="GridSystem.Grid.Check(string[])"/> in an argument represented as an array of strings.
        /// </summary>
        public const int CheckTargetYIdx = 1;

        /// <summary>
        /// The index of the <see cref="GridSystem.Grid.Map(string[])"/>'s bottom-left x-coordinate in an argument represented as an array of strings.
        /// </summary>
        public const int MapLeftXIdx = 0;

        /// <summary>
        /// The index of the <see cref="GridSystem.Grid.Map(string[])"/>'s bottom-left y-coordinate in an argument represented as an array of strings.
        /// </summary>
        public const int MapBottomYIdx = 1;

        /// <summary>
        /// The index of the <see cref="GridSystem.Grid.Map(string[])"/>'s width in an argument represented as an array of strings.
        /// </summary>
        public const int MapWidthIdx = 2;

        /// <summary>
        /// The index of the <see cref="GridSystem.Grid.Map(string[])"/>'s height in an argument represented as an array of strings.
        /// </summary>
        public const int MapHeightIdx = 3;

        /// <summary>
        /// The index of the <see cref="GridSystem.Grid.Path(string[])"/>'s starting x-coordinate in an argument represented as an array of strings.
        /// </summary>
        public const int StartXIdx = 0;

        /// <summary>
        /// The index of the <see cref="GridSystem.Grid.Path(string[])"/>'s starting y-coordinate in an argument represented as an array of strings.
        /// </summary>
        public const int StartYIdx = 1;

        /// <summary>
        /// The index of the <see cref="GridSystem.Grid.Path(string[])"/>'s ending x-coordinate in an argument represented as an array of strings.
        /// </summary>
        public const int EndXIdx = 2;

        /// <summary>
        /// The index of the <see cref="GridSystem.Grid.Path(string[])"/>'s ending y-coordinate in an argument represented as an array of strings.
        /// </summary>
        public const int EndYIdx = 3;

        /// <summary>
        /// Determines whether the length of an array of arguments is equal to the expected count.
        /// </summary>
        /// <param name="args">The arguments to check the length of.</param>
        /// <param name="expectedCount">The expected count.</param>
        /// <exception cref="IncorrectNumberOfArgumentsException">Thrown when the number of arguments does not match the expected count.</exception>
        public static void CompareArgsCount(string[] args, int expectedCount)
        {
            if (args.Length != expectedCount)
            {
                throw new IncorrectNumberOfArgumentsException(ErrorMessage.IncorrectNumberOfArgs, expectedCount);
            }
        }
    }
}
