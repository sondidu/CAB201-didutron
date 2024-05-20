using ConstantsAndHelpers;
using CustomExceptions;
namespace Didutron
{
    public abstract class Obstacle
    {
        protected readonly Coord pos;
        public char CharRep { get; protected set; }
        public Obstacle(string[] args)
        {
            string strX, strY;
            try
            {
                strX = args[IntConstant.CoordXIdx];
                strY = args[IntConstant.CoordYIdx];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IncorrectNumberOfArgumentsException(ex.Message, ex);
            }

            if (!int.TryParse(strX, out int x) || !int.TryParse(strY, out int y))
            {
                throw new IntArgumentException(ErrorMessage.InvalidCoord);
            }

            pos = new Coord(x, y);
        }
        public abstract bool HitObstacle(Coord target); 
    }
}
