using CustomExceptions;
using ConstantsAndHelpers;

namespace GridSystem
{
    /// <summary>
    /// Represents a Fence obstacle that extends in either the east or north direction for a specified length.
    /// </summary>
    public class Fence : Obstacle
    {
        private readonly string orientation;
        private readonly int length;

        /// <summary>
        /// Initialises a new instance of the <see cref="Fence"/> class.
        /// </summary>
        /// <param name="args">Arguments used to initialise the Fence.</param>
        /// <exception cref="IncorrectNumberOfArgumentsException">Thrown when the number of arguments does not match the expected count.</exception>
        /// <exception cref="StringArgumentException">Thrown when the orientation is not valid.</exception>
        /// <exception cref="IntArgumentException">Thrown when the length is not a valid integer or is less than or equal to 0.</exception>
        public Fence(string[] args) : base(args, ObstacleConstant.FenceChar)
        {
            ArgumentHelper.CompareArgsCount(args, ArgumentHelper.FenceArgsLength);

            string orientation = args[ArgumentHelper.OrientationIdx];
            if (orientation != Direction.East && orientation != Direction.North)
            {
                throw new StringArgumentException(ErrorMessage.InvalidOrientation);
            }

            string strLength = args[ArgumentHelper.LengthIdx];
            if (!int.TryParse(strLength, out int length) || length <= 0)
            {
                throw new IntArgumentException(ErrorMessage.InvalidLength);
            }

            this.orientation = orientation;
            this.length = length;
        }

        /// <summary>
        /// Determines whether the specified target hits the Fence.
        /// </summary>
        /// <param name="target">The target coordinates.</param>
        /// <returns>
        ///   <c>true</c> if <paramref name="target"/> hits the Fence; otherwise, <c>false</c>.
        /// </returns>
        public override bool HitObstacle(Coord target)
        {
            if (orientation == Direction.East)
            {
                return target.x >= pos.x && target.x < pos.x + length && target.y == pos.y;
            }
            return target.y >= pos.y && target.y < pos.y + length && target.x == pos.x; // North is implied
        }
    }
}
