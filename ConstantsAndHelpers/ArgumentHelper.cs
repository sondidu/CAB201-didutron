using CustomExceptions;
namespace ConstantsAndHelpers
{
    /// <summary>
    /// Provides constants and helper methods for handling arguments.
    /// </summary>
    public static class ArgumentHelper
    {
        // Argument lengths
        public const int MinimumObstacleLength = 2;
        public const int GuardArgsLength = 2;
        public const int FenceArgsLength = 4;
        public const int SensorArgsLength = 3;
        public const int CameraArgsLength = 3;
        public const int CheckArgsLength = 2;
        public const int MapArgsLength = 4;
        public const int PathArgsLength = 4;
        public const int NoArgs = 0;

        // Argument indexes
        public const int CoordXIdx = 0;
        public const int CoordYIdx = 1;
        public const int OrientationIdx = 2;
        public const int LengthIdx = 3;
        public const int RadiusIdx = 2;
        public const int DirectionIdx = 2;
        public const int CheckTargetXIdx = 0;
        public const int CheckTargetYIdx = 1;
        public const int MapLeftXIdx = 0;
        public const int MapBottomYIdx = 1;
        public const int MapWidthIdx = 2;
        public const int MapHeightIdx = 3;
        public const int StartXIdx = 0;
        public const int StartYIdx = 1;
        public const int EndXIdx = 2;
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
