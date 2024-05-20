using ConstantsAndHelpers;
namespace Didutron
{
    public class Guard : Obstacle
    {
        public Guard(string[] args) : base(args)
        {
            IntConstant.CompareArgsCount(args, IntConstant.GuardArgsLength);
            CharRep = ObstacleConstant.GuardChar;
        }
        public override bool HitObstacle(Coord target)
        {
            return target == pos;
        }
    }
}
