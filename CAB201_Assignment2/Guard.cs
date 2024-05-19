using ConstantsAndHelpers;
namespace Didutron
{
    public class Guard : Obstacle
    {
        public Guard(string[] args) : base(args)
        {
            IntConstants.CompareArgsCount(args, IntConstants.GuardArgsLength);
            charRep = ObstacleChars.Guard;
        }
        public override bool HitObstacle(int targetX, int targetY)
        {
            return x == targetX && y == targetY;
        }
    }
}
