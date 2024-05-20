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
            if (direction != Direction.East && direction != Direction.West && direction != Direction.North && direction != Direction.South)
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
                Direction.East => targetX >= x && diffY <= diffX,
                Direction.West => targetX <= x && diffY <= diffX,
                Direction.North => targetY >= y && diffX <= diffY,
                _ => targetY <= y && diffX <= diffY, // "south" is implied
            };
        }
    }
}
