using ConstantsAndHelpers;
namespace Didutron
{
    public class ObstacleFactory
    {
        private readonly Grid grid;
        private readonly ObstacleType type;
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
                    obstacleName = ObstacleConstants.GuardName;
                    break;
                case ObstacleType.Fence:
                    obstacle = new Fence(args);
                    obstacleName = ObstacleConstants.FenceName;
                    break;
                case ObstacleType.Sensor:
                    obstacle = new Sensor(args);
                    obstacleName = ObstacleConstants.SensorName;
                    break;
                case ObstacleType.Camera:
                    obstacle = new Camera(args);
                    obstacleName = ObstacleConstants.CameraName;
                    break;
                default:
                    throw new Exception(ErrorMessages.InvalidObstacle);
            }
            grid.AddObstacle(obstacle);
            Console.WriteLine(SuccessMessages.AddedObstacle, obstacleName);
        }
    }
}
