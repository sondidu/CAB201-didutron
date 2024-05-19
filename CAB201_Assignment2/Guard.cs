namespace Didutron
{
    public class Guard : Obstacle
    {
        private const char DEFAULT_GUARD_CHAR = 'G';
        public Guard(int x, int y) : base(x, y)
        {
            charRep = DEFAULT_GUARD_CHAR;
        }

        public override bool HitObstacle(int targetX, int targetY)
        {
            return x == targetX && y == targetY;
        }
    }
}
