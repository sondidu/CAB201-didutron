namespace Didutron
{
    public enum ObstacleType
    {
        Guard,
        Fence,
        Sensor,
        Camera
    }
    public class ObstacleFactory
    {
        private const string SuccessfullyAddedMsg = "Successfully added {0} obstacle.";
        private Grid grid;
        private ObstacleType type;
        public ObstacleFactory(Grid grid, ObstacleType type)
        {
            this.grid = grid;
            this.type = type;
        }
        public void AddToGrid(string[] args)
        {
            Obstacle obstacle;
            string obstacleName;
            switch (type)
            {
                case ObstacleType.Guard:
                    obstacle = new Guard(args);
                    obstacleName = "guard";
                    break;
                case ObstacleType.Fence:
                    obstacle = new Fence(args);
                    obstacleName = "fence";
                    break;
                case ObstacleType.Sensor:
                    obstacle = new Sensor(args);
                    obstacleName = "sensor";
                    break;
                case ObstacleType.Camera:
                    obstacle = new Camera(args);
                    obstacleName = "camera";
                    break;
                default:
                    throw new ArgumentException("Invalid obstacle type.");
            }
            grid.AddObstacle(obstacle);
            Console.WriteLine(SuccessfullyAddedMsg, obstacleName);
        }
    }
}
