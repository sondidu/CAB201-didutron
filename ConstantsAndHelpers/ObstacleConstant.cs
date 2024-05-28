namespace ConstantsAndHelpers
{
    /// <summary>
    /// Provides constants for the obstacles used.
    /// </summary>
    public static class ObstacleConstant
    {
        /// <summary>
        /// The default character representation of a <see cref="GridSystem.Guard"/> obstacle.
        /// </summary>
        public const char GuardChar = 'G';

        /// <summary>
        /// The default character representation of a <see cref="GridSystem.Fence"/> obstacle.
        /// </summary>
        public const char FenceChar = 'F';

        /// <summary>
        /// The default character representation of a <see cref="GridSystem.Sensor"/> obstacle.
        /// </summary>
        public const char SensorChar = 'S';

        /// <summary>
        /// The default character representation of a <see cref="GridSystem.Camera"/> obstacle.
        /// </summary>
        public const char CameraChar = 'C';

        /// <summary>
        /// The default character representation of an empty coordinate.
        /// </summary>
        public const char EmptyChar = '.';

        /// <summary>
        /// The default name of a <see cref="GridSystem.Guard"/> obstacle.
        /// </summary>
        public const string GuardName = "guard";

        /// <summary>
        /// The default name of a <see cref="GridSystem.Fence"/> obstacle.
        /// </summary>
        public const string FenceName = "fence";

        /// <summary>
        /// The default name of a <see cref="GridSystem.Sensor"/> obstacle.
        /// </summary>
        public const string SensorName = "sensor";

        /// <summary>
        /// The default name of a <see cref="GridSystem.Camera"/> obstacle.
        /// </summary>
        public const string CameraName = "camera";
    }
}
