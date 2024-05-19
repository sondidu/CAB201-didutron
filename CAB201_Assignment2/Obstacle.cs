using CustomExceptions;
namespace Didutron
{
    public abstract class Obstacle
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public char charRep { get; protected set; }
        private const string INVALID_COORD_MSG = "Coordinates are not valid integers.";
        public Obstacle(string strX, string strY)
        {
            if (!int.TryParse(strX, out int x) || !int.TryParse(strY, out int y))
            {
                throw new IntArgumentException(INVALID_COORD_MSG);
            }
            this.x = x;
            this.y = y;
        }
        public abstract bool HitObstacle(int targetX, int targetY);
    }
}
