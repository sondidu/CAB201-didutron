namespace Didutron
{
    public class Camera : Obstacle
    {
        private const char DEFAULT_CAMERA_CHAR = 'C';
        private readonly string direction;
        public Camera(int x, int y, string direction) : base(x, y)
        {
            charRep = DEFAULT_CAMERA_CHAR;
            this.direction = direction;
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
                // default will throw an error lol
            }
            return false;
        }
    }
}
