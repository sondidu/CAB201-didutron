using CustomExceptions;
namespace ConstantsAndHelpers
{
    public static class IntConstants
    {
        public const int GuardArgsLength = 2;
        public const int FenceArgsLength = 4;
        public const int SensorArgsLength = 3;
        public const int CameraArgsLength = 3;
        public const int CheckArgsLength = 2;
        public const int MapArgsLength = 4;
        public const int PathArgsLength = 4;
        public const int NoArgs = 0;

        public const int CoordXIdx = 0;
        public const int CoordYIdx = 1;
        public const int OrientationIdx = 2;
        public const int LengthIdx = 3;
        public const int RadiusIdx = 2;
        public const int DirectionIdx = 2;
        public const int CheckTargetXIdx = 0;
        public const int CheckTargetYIdx = 1;
        public const int MapLeftBorderXIdx = 0;
        public const int MapBottomBorderYIdx = 1;
        public const int MapWidthIdx = 2;
        public const int MapHeightIdx = 3;
        public const int StartXIdx = 0;
        public const int StartYIdx = 1;
        public const int EndXIdx = 2;
        public const int EndYIdx = 3;

        public static void CompareArgsCount(string[] args, int expectedCount)
        {
            if (args.Length != expectedCount)
            {
                throw new IncorrectNumberOfArgumentsException();
            }
        }
    }
}
