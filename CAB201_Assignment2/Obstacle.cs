using ConstantsAndHelpers;
using CustomExceptions;
namespace Didutron
{
    public abstract class Obstacle
    {
        protected readonly Coord pos;
        public readonly char CharRep;

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

        public abstract bool HitObstacle(Coord target); 
    }
}
