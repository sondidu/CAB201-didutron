using CustomExceptions;
using ConstantsAndHelpers;
namespace Didutron
{
    public class Fence : Obstacle
    {
        private readonly string orientation;
        private readonly int length;
        public Fence(string[] args) : base(args)
        {
            IntConstants.CompareArgsCount(args, IntConstants.FenceArgsLength);

            string orientation = args[IntConstants.OrientationIdx];
            if (orientation != "east" && orientation != "west")
            {
                throw new StringArgumentException(ErrorMessages.InvalidOrientation);
            }

            string strLength = args[IntConstants.LengthIdx];
            if (!int.TryParse(strLength, out int length) || length <= 0)
            {
                throw new IntArgumentException(ErrorMessages.InvalidLength);
            }
            this.orientation = orientation;
            this.length = length;
            charRep = ObstacleChars.Fence;
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
