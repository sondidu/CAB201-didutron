namespace Didutron
{
    public class SensorFactory : ObstacleFactory
    {
        public SensorFactory(Grid grid) : base(grid) { }
        private const string SUCCESS_PROMPT = "Successfully added sensor obstacle.";
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
            double radius = double.Parse(args[2]);

            return new Sensor(x, y, radius);
        }
    }
}
