using CustomExceptions;
using ConstantsAndHelpers;
namespace GridSystem
{
    /// <summary>
    /// Represents a camera obstacle that covers an infinite triangular area in a specified direction.
    /// </summary>
    public class Camera : Obstacle
    {
        private readonly string direction;

        /// <summary>
        /// Initialises a new instance of the <see cref="Camera"/> obstacle.
        /// </summary>
        /// <param name="args">The arguments used to initialise the Camera.</param>
        /// <exception cref="IncorrectNumberOfArgumentsException">Thrown when the number of arguments does not match the expected count.</exception>
        /// <exception cref="StringArgumentException">Thrown when the direction is not valid.</exception>
        public Camera(string[] args) : base(args, ObstacleConstant.CameraChar)
        {
            ArgumentHelper.CompareArgsCount(args, ArgumentHelper.CameraArgsLength);

            string direction = args[ArgumentHelper.DirectionIdx];
            if (direction != Direction.East && direction != Direction.West && direction != Direction.North && direction != Direction.South)
            {
                throw new StringArgumentException(ErrorMessage.InvalidDirection);
            }

            this.direction = direction;
        }

        /// <summary>
        /// Determines whether the specified target is within range of the Camera.
        /// </summary>
        /// <param name="target">The target coordinates.</param>
        /// <returns>
        ///  <c>true</c> if <paramref name="target"/> is within the range of the Camera; otherwise, <c>false</c>.
        /// </returns>
        public override bool HitObstacle(Coord target)
        {
            int diffX = Math.Abs(target.x - pos.x);
            int diffY = Math.Abs(target.y - pos.y);
            return direction switch
            {
                Direction.East => target.x >= pos.x && diffY <= diffX,
                Direction.West => target.x <= pos.x && diffY <= diffX,
                Direction.North => target.y >= pos.y && diffX <= diffY,
                _ => target.y <= pos.y && diffX <= diffY, // South is implied
            };
        }
    }
}
