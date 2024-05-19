namespace Didutron
{
    public class Sensor : Obstacle
    {
        private const char DEFAULT_SENSOR_CHAR = 'S';
        private readonly double radius;
        public Sensor(int x, int y, double radius) : base(x, y)
        {
            charRep = DEFAULT_SENSOR_CHAR;
            this.radius = radius;
        }
        public override bool HitObstacle(int targetX, int targetY)
        {
            double diffX = targetX - x;
            double diffY = targetY - y;
            return diffX * diffX + diffY * diffY < radius * radius; 
        }
    }
}
