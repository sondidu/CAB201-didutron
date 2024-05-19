namespace Didutron
{
    public class GuardFactory : ObstacleFactory
    {
        public GuardFactory(Grid grid) : base(grid) { }
        private const string SUCCESS_PROMPT = "Successfully added guard obstacle.";
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

            return new Guard(x, y);
        }
    }
}
