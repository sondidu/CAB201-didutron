using CustomExceptions;
using ConstantsAndHelpers;
namespace Didutron
{
    public class Sensor : Obstacle
    {
        private readonly double radius;
        public Sensor(string[] args) : base(args)
        {
            IntConstants.CompareArgsCount(args, IntConstants.SensorArgsLength);

            string strRadius = args[IntConstants.RadiusIdx];
            if (!double.TryParse(strRadius, out double radius) || radius <= 0)
            {
                throw new DoubleArgumentException(ErrorMessages.InvalidRadius);
            }

            this.radius = radius;
            CharRep = ObstacleConstants.SensorChar;
        }
        public override bool HitObstacle(int targetX, int targetY)
        {
            double diffX = targetX - x;
            double diffY = targetY - y;
            return diffX * diffX + diffY * diffY < radius * radius; 
        }
    }
}
