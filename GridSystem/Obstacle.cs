using ConstantsAndHelpers;
using CustomExceptions;

namespace GridSystem
{
    /// <summary>
    /// Abstract class of an obstacle.
    /// </summary>
    public abstract class Obstacle
    {
        /// <summary>
        /// Position of the obstacle in the grid.
        /// </summary>
        protected readonly Coord pos;

        /// <summary>
        /// Character representation of the obstacle.
        /// </summary>
        public readonly char CharRep;

        /// <summary>
        /// Initialises a new instance of the <see cref="Obstacle"/> class.
        /// </summary>
        /// <param name="args">Arguments used to initialise the obstacle.</param>
        /// <param name="charRep">Character representation of the obstacle.</param>
        /// <exception cref="IncorrectNumberOfArgumentsException">Thrown when the number of arguments is incorrect.</exception>
        /// <exception cref="IntArgumentException">Thrown when the coordinates are not valid intagers.</exception>
        public Obstacle(string[] args, char charRep)
        {
            string strX, strY;
            try
            {
                strX = args[ArgumentHelper.CoordXIdx];
                strY = args[ArgumentHelper.CoordYIdx];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IncorrectNumberOfArgumentsException(ex.Message, ArgumentHelper.MinimumObstacleLength, ex);
            }

            if (!int.TryParse(strX, out int x) || !int.TryParse(strY, out int y))
            {
                throw new IntArgumentException(ErrorMessage.InvalidCoord);
            }

            pos = new Coord(x, y);
            CharRep = charRep;
        }

        /// <summary>
        /// Determines whether the specified target hits the obstacle.
        /// </summary>
        /// <param name="target">The target coordintaes.</param>
        /// <returns>
        ///   <c>true</c> if <paramref name="target"/> hits the obstacle; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool HitObstacle(Coord target);
    }
}
