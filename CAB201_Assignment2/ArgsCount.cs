using CustomExceptions;
namespace Didutron
{
    public static class ArgsCount
    {
        public const int Guard = 2;
        public const int Fence = 4;
        public const int Sensor = 3;
        public const int Camera = 3;
        public const int Check = 2;
        public const int Map = 4;
        public const int Path = 4;
        public const int NoArgs = 0;

        public static void CheckArgsCount(string[] args, int expectedCount)
        {
            if (args.Length != expectedCount)
            {
                throw new IncorrectNumberOfArgumentsException();
            }
        }
    }
}
