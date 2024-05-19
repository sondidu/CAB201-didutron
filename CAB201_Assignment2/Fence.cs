using CustomExceptions;

namespace Didutron
{
    public class Fence : Obstacle
    {
        private readonly string orientation;
        private readonly int length;
        private const char DEFAULT_FENCE_CHAR = 'F';
        private const string INVALID_ORIENTATION_MSG = "Orientation must be 'east' or 'north'.";
        private const string INVALID_LENGTH_MSG = "Length must be a valid integer greater than 0.";
        public Fence(string[] args) : base(args[0], args[1])
        {
            ArgsCount.CheckArgsCount(args, ArgsCount.Fence);

            string orientation = args[2];
            if (orientation != "east" && orientation != "west")
            {
                throw new StringArgumentException(INVALID_ORIENTATION_MSG);
            }
            if (!int.TryParse(args[3], out int length) || length <= 0)
            {
                throw new IntArgumentException(INVALID_LENGTH_MSG);
            }
            this.orientation = orientation;
            this.length = length;
            charRep = DEFAULT_FENCE_CHAR;
        }

        public override bool HitObstacle(int targetX, int targetY)
        {
            if (orientation == "east")
            {
                return targetX >= x && targetX < x + length && targetY == y;
            }
            return targetY >= y && targetY < y + length && targetX == x;
        }
    }
}
