namespace ConstantsAndHelpers
{
    /// <summary>
    /// Provides constants for command keys.
    /// </summary>
    public static class CommandKey
    {
        /// <summary>
        /// The command key for <see cref="GridSystem.Grid.AddObstacle(GridSystem.Obstacle)"/>.
        /// </summary>
        public const string Add = "add";

        /// <summary>
        /// The command key for <see cref="GridSystem.Guard"/>.
        /// </summary>
        public const string Guard = ObstacleConstant.GuardName;

        /// <summary>
        /// The command key for <see cref="GridSystem.Fence"/>.
        /// </summary>
        public const string Fence = ObstacleConstant.FenceName;

        /// <summary>
        /// The command key for <see cref="GridSystem.Sensor"/>.
        /// </summary>
        public const string Sensor = ObstacleConstant.SensorName;

        /// <summary>
        /// The command key for <see cref="GridSystem.Camera"/>.
        /// </summary>
        public const string Camera = ObstacleConstant.CameraName;

        /// <summary>
        /// The command key for <see cref="GridSystem.Grid.Check(string[])"/>.
        /// </summary>
        public const string Check = "check";

        /// <summary>
        /// The command key for <see cref="GridSystem.Grid.Map(string[])"/>.
        /// </summary>
        public const string Map = "map";

        /// <summary>
        /// The command key for <see cref="GridSystem.Grid.Path(string[])"/>.
        /// </summary>
        public const string Path = "path";

        /// <summary>
        /// The command key for <see cref="GridSystem.MessageDisplay.ListCommands(string[])"/>.
        /// </summary>
        public const string Help = "help";

        /// <summary>
        /// The command key for <see cref="GridSystem.MessageDisplay.Exit(string[])"/>.
        /// </summary>
        public const string Exit = "exit";
    }
}
