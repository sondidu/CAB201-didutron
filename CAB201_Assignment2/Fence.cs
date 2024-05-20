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
            if (orientation != Direction.East && orientation != Direction.North)
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
            CharRep = ObstacleConstants.FenceChar;
        }

        public override bool HitObstacle(int targetX, int targetY)
        {
            if (orientation == Direction.East)
            {
                return targetX >= x && targetX < x + length && targetY == y;
            }
            return targetY >= y && targetY < y + length && targetX == x;
        }
    }
}
