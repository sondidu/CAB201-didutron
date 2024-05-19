using CustomExceptions;
namespace Didutron
{
    public class Guard : Obstacle
    {
        private const char DEFAULT_GUARD_CHAR = 'G';
        public Guard(string[] args) : base(args[0], args[1])
        {
            charRep = DEFAULT_GUARD_CHAR;
        }
        public override bool HitObstacle(int targetX, int targetY)
        {
            return x == targetX && y == targetY;
        }
    }
}
