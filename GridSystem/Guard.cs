using ConstantsAndHelpers;

namespace GridSystem
{
    /// <summary>
    /// Represents a Guard obstacle that covers a single position.
    /// </summary>
    public class Guard : Obstacle
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Guard"/> class.
        /// </summary>
        /// <param name="args">Arguments used to initialise the Guard.</param>
        /// <exception cref="CustomExceptions.IncorrectNumberOfArgumentsException">Thrown when the number of arguments does not match the expected count.</exception>
        public Guard(string[] args) : base(args, ObstacleConstant.GuardChar)
        {
            ArgumentHelper.CompareArgsCount(args, ArgumentHelper.GuardArgsLength);
        }

        /// <summary>
        /// Determines whether the specified target hits the Guard.
        /// </summary>
        /// <param name="target">The target coordinates.</param>
        /// <returns>
        ///   <c>true</c> if <paramref name="target"/> has the same position as the Guard; otherwise, <c>false</c>.
        /// </returns>
        public override bool HitObstacle(Coord target)
        {
            return target == pos;
        }
    }
}
