namespace Didutron
{
    public class CameraFactory : ObstacleFactory
    {
        public CameraFactory(Grid grid) : base(grid) { }
        private const string SUCCESS_PROMPT = "Successfully added camera obstacle.";
        protected override string SuccessfullyAddedMsg
        {
            get
            {
                return SUCCESS_PROMPT;
            }
        }
        protected override Obstacle CreateObstacle(string[] args)
        {
            int x = int.Parse(args[0]);
            int y = int.Parse(args[1]);
            string direction = args[2];

            return new Camera(x, y, direction);
        }
    }
}
