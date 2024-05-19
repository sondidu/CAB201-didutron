using CustomExceptions;
namespace Didutron
{
    public abstract class Obstacle
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public char charRep { get; protected set; }
        private const string INVALID_COORD_MSG = "Coordinates are not valid integers.";
        public Obstacle(string[] args)
        {
            const int CoordXIdx = 0;
            const int CoordYIdx = 1;

            string strX, strY;
            try
            {
                strX = args[CoordXIdx];
                strY = args[CoordYIdx];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IncorrectNumberOfArgumentsException("", ex);
            }

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
