using ConstantsAndHelpers;
namespace Didutron
{
    public class Guard : Obstacle
    {
        public Guard(string[] args) : base(args)
        {
            IntConstants.CompareArgsCount(args, IntConstants.GuardArgsLength);
            CharRep = ObstacleConstants.GuardChar;
        }
    }
}
