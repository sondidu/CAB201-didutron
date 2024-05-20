using CustomExceptions;
using ConstantsAndHelpers;
namespace Didutron
{
    public class Camera : Obstacle
    {
        private readonly string direction;
        public Camera(string[] args) : base(args)
        {
            IntConstant.CompareArgsCount(args, IntConstant.CameraArgsLength);

            string direction = args[IntConstant.DirectionIdx];
            if (direction != Direction.East && direction != Direction.West && direction != Direction.North && direction != Direction.South)
            {
                throw new StringArgumentException(ErrorMessage.InvalidDirection);
            }

            this.direction = direction;
            CharRep = ObstacleConstant.CameraChar;
        }
        public override bool HitObstacle(Coord target)
        {
            int diffX = Math.Abs(target.x - pos.x);
            int diffY = Math.Abs(target.y - pos.y);
            return direction switch
            {
                Direction.East => target.x >= pos.x && diffY <= diffX,
                Direction.West => target.x <= pos.x && diffY <= diffX,
                Direction.North => target.y >= pos.y && diffX <= diffY,
                _ => target.y <= pos.y && diffX <= diffY, // South is implied
            };
        }
    }
}
