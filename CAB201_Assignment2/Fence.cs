using CustomExceptions;
using ConstantsAndHelpers;
namespace Didutron
{
    public class Fence : Obstacle
    {
        private readonly string orientation;
        private readonly int length;

        public Fence(string[] args) : base(args, ObstacleConstant.FenceChar)
        {
            ArgumentHelper.CompareArgsCount(args, ArgumentHelper.FenceArgsLength);

            string orientation = args[ArgumentHelper.OrientationIdx];
            if (orientation != Direction.East && orientation != Direction.North)
            {
                throw new StringArgumentException(ErrorMessage.InvalidOrientation);
            }

            string strLength = args[ArgumentHelper.LengthIdx];
            if (!int.TryParse(strLength, out int length) || length <= 0)
            {
                throw new IntArgumentException(ErrorMessage.InvalidLength);
            }

            this.orientation = orientation;
            this.length = length;
        }

        public override bool HitObstacle(Coord target)
        {
            if (orientation == Direction.East)
            {
                return target.x >= pos.x && target.x < pos.x + length && target.y == pos.y;
            }
            return target.y >= pos.y && target.y < pos.y + length && target.x == pos.x; // North is implied
        }
    }
}
