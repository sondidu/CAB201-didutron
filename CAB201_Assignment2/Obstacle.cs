namespace Didutron
{
    public abstract class Obstacle
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public char charRep { get; protected set; }
        public Obstacle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public abstract bool HitObstacle(int targetX, int targetY);
    }
}
