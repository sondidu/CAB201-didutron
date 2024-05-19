using CustomExceptions;
using ConstantsAndHelpers;
namespace Didutron
{
    public class Camera : Obstacle
    {
        private readonly string direction;
        public Camera(string[] args) : base(args)
        {
            IntConstants.CompareArgsCount(args, IntConstants.CameraArgsLength);

            string direction = args[IntConstants.DirectionIdx];
            if (direction != "east" && direction != "west" && direction != "north" && direction != "south")
            {
                throw new StringArgumentException(ErrorMessages.InvalidDirection);
            }
            this.direction = direction;
            CharRep = ObstacleConstants.CameraChar;
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
                _ => targetY <= y && diffX <= diffY, // "south" is implied
            };
        }
    }
}
