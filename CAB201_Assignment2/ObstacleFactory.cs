namespace Didutron
{
    public abstract class ObstacleFactory
    {
        protected abstract string SuccessfullyAddedMsg { get; }
        private Grid grid;
        public ObstacleFactory(Grid grid)
        {
            this.grid = grid;
        }
        protected abstract Obstacle CreateObstacle(string[] args);
        public void AddToGrid(string[] args)
        {
            grid.AddObstacle(CreateObstacle(args));
            Console.WriteLine(SuccessfullyAddedMsg);
        }
    }
}
