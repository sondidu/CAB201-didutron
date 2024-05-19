namespace Didutron
{
    public class Fence : Obstacle
    {
        private const char DEFAULT_FENCE_CHAR = 'F';
        private readonly string orientation;
        private readonly int length;
        public Fence(int x, int y, string orientation, int length) : base(x, y)
        {
            charRep = DEFAULT_FENCE_CHAR;
            this.orientation = orientation;
            this.length = length;
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
