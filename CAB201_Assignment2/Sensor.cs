using CustomExceptions;
using ConstantsAndHelpers;
namespace Didutron
{
    public class Sensor : Obstacle
    {
        private readonly double radius;
        public Sensor(string[] args) : base(args)
        {
            IntConstant.CompareArgsCount(args, IntConstant.SensorArgsLength);

            string strRadius = args[IntConstant.RadiusIdx];
            if (!double.TryParse(strRadius, out double radius) || radius <= 0)
            {
                throw new DoubleArgumentException(ErrorMessage.InvalidRadius);
            }

            this.radius = radius;
            CharRep = ObstacleConstant.SensorChar;
        }
        public override bool HitObstacle(Coord target)
        {
            double diffX = target.x - pos.x;
            double diffY = target.y - pos.y;
            return diffX * diffX + diffY * diffY < radius * radius; 
        }
    }
}
