using ConstantsAndHelpers;
using CustomExceptions;
namespace Didutron
{
    public abstract class Obstacle
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public char CharRep { get; protected set; }
        public Obstacle(string[] args)
        {
            string strX, strY;
            try
            {
                strX = args[IntConstants.CoordXIdx];
                strY = args[IntConstants.CoordYIdx];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IncorrectNumberOfArgumentsException(ex.Message, ex);
            }

            if (!int.TryParse(strX, out int x) || !int.TryParse(strY, out int y))
            {
                throw new IntArgumentException(ErrorMessages.InvalidCoord);
            }

            this.x = x;
            this.y = y;
        }
        public virtual bool HitObstacle(int targetX, int targetY)
        {
            return targetX == x && targetY == y;
        }
    }
}
