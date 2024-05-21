using CustomExceptions;
using ConstantsAndHelpers;
namespace GridSystem
{
    /// <summary>
    /// Represents a Sensor obstacle that covers a circular area for a specified radius.
    /// </summary>
    public class Sensor : Obstacle
    {
        private readonly double radius;

        /// <summary>
        /// Initialises a new instance of the <see cref="Sensor" /> class.
        /// </summary>
        /// <param name="args">The arguments used to initialise the Sensor.</param>
        /// <exception cref="IncorrectNumberOfArgumentsException">Thrown when the number of arguments does not match the expected count.</exception>
        /// <exception cref="DoubleArgumentException">Thrown when the radius is not a valid double or is less than or equal to 0.</exception>
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

        /// <summary>
        /// Determines whether the specified target is within the radius of the Sensor.
        /// </summary>
        /// <param name="target">The target coordinates.</param>
        /// <returns><c>true</c> if <paramref name="target"/> is within the radius of the Sensor.</returns>
        public override bool HitObstacle(Coord target)
        {
            double diffX = target.x - pos.x;
            double diffY = target.y - pos.y;
            return diffX * diffX + diffY * diffY < radius * radius; 
        }
    }
}
