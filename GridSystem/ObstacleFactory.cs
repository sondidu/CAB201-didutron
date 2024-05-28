using ConstantsAndHelpers;

namespace GridSystem
{
    /// <summary>
    /// Represents a factory for creating and adding obstacles to a grid.
    /// </summary>
    public class ObstacleFactory
    {
        private readonly Grid grid;
        private readonly ObstacleType obstacleType;

        /// <summary>
        /// Initialises a new instance of the <see cref="ObstacleFactory"/> class.
        /// </summary>
        /// <param name="grid">The grid to which obstacles are added.</param>
        /// <param name="obstacleType">The type of obstacle to create.</param>
        public ObstacleFactory(Grid grid, ObstacleType obstacleType)
        {
            this.grid = grid;
            this.obstacleType = obstacleType;
        }

        /// <summary>
        /// Creates an obstacle of the specified type and adds it to the grid.
        /// </summary>
        /// <param name="args">The arguments used to initialise the obstacle.</param>
        /// <exception cref="Exception">Thrown when the obstacle type enum is invalid.</exception>
        public void AddToGrid(string[] args)
        {
            Obstacle obstacle;
            string obstacleName;
            switch (obstacleType)
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
                    throw new Exception(ErrorMessage.DefaultInvalidObstacleEnum);
            }
            grid.AddObstacle(obstacle);
            Console.WriteLine(SuccessMessage.AddedObstacleFormat, obstacleName);
        }
    }
}
