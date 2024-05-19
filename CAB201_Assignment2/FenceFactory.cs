namespace Didutron
{
    public class FenceFactory : ObstacleFactory
    {
        public FenceFactory(Grid grid) : base(grid) { }
        private const string SUCCESS_PROMPT = "Successfully added fence obstacle.";
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
            string orientation = args[2];
            int length = int.Parse(args[3]);

            return new Fence(x, y, orientation, length);
        }
    }
}
