using CustomExceptions;

namespace Didutron
{
    public class Camera : Obstacle
    {
        private const char DEFAULT_CAMERA_CHAR = 'C';
        private readonly string direction;
        private const string INVALID_DIRECTION_MSG = "Direction must be 'north', 'south', 'east' or 'west'.";
        public Camera(string[] args) : base(args)
        {
            ArgsCount.CheckArgsCount(args, ArgsCount.Camera);

            const int DirectionIdx = 2;

            string direction = args[DirectionIdx];
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
            return direction switch
            {
                "east" => targetX >= x && diffY <= diffX,
                "west" => targetX <= x && diffY <= diffX,
                "north" => targetY >= y && diffX <= diffY,
                "south" => targetY <= y && diffX <= diffY,
                _ => false, // TODO: Remove this line and set the default case to the case to handle "south"
            };
        }
    }
}
