using CustomExceptions;
using ConstantsAndHelpers;
namespace GridSystem
{
    public class Sensor : Obstacle
    {
        private readonly double radius;
        public Sensor(string[] args) : base(args, ObstacleConstant.SensorChar)
        {
            ArgumentHelper.CompareArgsCount(args, ArgumentHelper.SensorArgsLength);

            string strRadius = args[ArgumentHelper.RadiusIdx];
            if (!double.TryParse(strRadius, out double radius) || radius <= 0)
            {
                throw new DoubleArgumentException(ErrorMessage.InvalidRadius);
            }

            this.radius = radius;
        }
        public override bool HitObstacle(Coord target)
        {
            double diffX = target.x - pos.x;
            double diffY = target.y - pos.y;
            return diffX * diffX + diffY * diffY < radius * radius; 
        }
    }
}
