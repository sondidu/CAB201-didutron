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
            IntConstant.CompareArgsCount(args, IntConstant.FenceArgsLength);

            string orientation = args[IntConstant.OrientationIdx];
            if (orientation != Direction.East && orientation != Direction.North)
            {
                throw new StringArgumentException(ErrorMessage.InvalidOrientation);
            }

            string strLength = args[IntConstant.LengthIdx];
            if (!int.TryParse(strLength, out int length) || length <= 0)
            {
                throw new IntArgumentException(ErrorMessage.InvalidLength);
            }

            this.orientation = orientation;
            this.length = length;
            CharRep = ObstacleConstant.FenceChar;
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
