using CustomExceptions;

namespace Didutron
{
    public class Camera : Obstacle
    {
        private const char DEFAULT_CAMERA_CHAR = 'C';
        private readonly string direction;
        private const string INVALID_DIRECTION_MSG = "Direction must be 'north', 'south', 'east' or 'west'.";
        public Camera(string[] args) : base(args[0], args[1])
        {
            ArgsCount.CheckArgsCount(args, ArgsCount.Camera);

            string direction = args[2];
            if (direction != "east" && direction != "west" && direction != "north" && direction != "south")
            {
                throw new StringArgumentException(INVALID_DIRECTION_MSG);
            }
            this.direction = direction;
            charRep = DEFAULT_CAMERA_CHAR;
        }
        public override bool HitObstacle(int targetX, int targetY)
        {
            int diffX = Math.Abs(targetX - x);
            int diffY = Math.Abs(targetY - y);
            switch(direction)
            {
                case "east":
                    return targetX >= x && diffY <= diffX;
                case "west":
                    return targetX <= x && diffY <= diffX;
                case "north":
                    return targetY >= y && diffX <= diffY;
                case "south":
                    return targetY <= y && diffX <= diffY;
            }
            return false;
        }
    }
}
