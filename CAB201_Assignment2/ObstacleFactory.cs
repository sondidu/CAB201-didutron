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
                    obstacleName = ObstacleConstant.GuardName;
                    break;
                case ObstacleType.Fence:
                    obstacle = new Fence(args);
                    obstacleName = ObstacleConstant.FenceName;
                    break;
                case ObstacleType.Sensor:
                    obstacle = new Sensor(args);
                    obstacleName = ObstacleConstant.SensorName;
                    break;
                case ObstacleType.Camera:
                    obstacle = new Camera(args);
                    obstacleName = ObstacleConstant.CameraName;
                    break;
                default:
                    throw new Exception(ErrorMessage.InvalidObstacle);
            }
            grid.AddObstacle(obstacle);
            Console.WriteLine(SuccessMessage.AddedObstacle, obstacleName);
        }
    }
}
