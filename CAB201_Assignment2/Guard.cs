using ConstantsAndHelpers;
namespace Didutron
{
    public class Guard : Obstacle
    {
        public Guard(string[] args) : base(args, ObstacleConstant.GuardChar)
        {
            ArgumentHelper.CompareArgsCount(args, ArgumentHelper.GuardArgsLength);
        }

        public override bool HitObstacle(Coord target)
        {
            return target == pos;
        }
    }
}
