namespace ConstantsAndHelpers
{
    /// <summary>
    /// Provides error messages.
    /// </summary>
    public static class ErrorMessage
    {
        /* Functionality-related messages */

        /// <summary>
        /// The message when the raw input of a coordinate is invalid.
        /// </summary>
        public const string InvalidCoord = "Coordinates are not valid integers.";

        /// <summary>
        /// The message when the raw input of a <see cref="GridSystem.Fence"/>'s orientation is invalid.
        /// </summary>
        public const string InvalidOrientation = "Orientation must be 'east' or 'north'.";

        /// <summary>
        /// The message when the raw input of a <see cref="GridSystem.Fence"/>'s length is invalid.
        /// </summary>
        public const string InvalidLength = "Length must be a valid integer greater than 0.";

        /// <summary>
        /// The message when the raw input of a <see cref="GridSystem.Sensor"/>'s radius is invalid.
        /// </summary>
        public const string InvalidRadius = "Range must be a valid positive number.";

        /// <summary>
        /// The message when the raw input of a <see cref="GridSystem.Camera"/>'s direciton is invalid.
        /// </summary>
        public const string InvalidDirection = "Direction must be 'north', 'south', 'east' or 'west'.";

        /// <summary>
        /// The message when the raw input of the map's dimensions are invalid.
        /// Used in <see cref="GridSystem.Grid.Map(string[])"/>.
        /// </summary>
        public const string InvalidMapDimensions = "Width and height must be valid positive integers.";

        /// <summary>
        /// The message when the raw input of an agent's coordinates are invalid.
        /// Used in <see cref="GridSystem.Grid.Path(string[])"/>.
        /// </summary>
        public const string InvalidAgentCoord = "Agent coordinates are not valid integers.";

        /// <summary>
        /// The message when the raw input of an objective's coordinates are invalid.
        /// Used in <see cref="GridSystem.Grid.Path(string[])"/>.
        /// </summary>
        public const string InvalidObjectiveCoord = "Objective coordinates are not valid integers.";

        /// <summary>
        /// The message when the agent's location is not safe.
        /// Used in <see cref="GridSystem.Grid.Check(GridSystem.Coord)"/>.
        /// </summary>
        public const string UnsafeCoord = "Agent your location is compromised. Abort mission";

        /// <summary>
        /// The message when there are no safe directions from a location.
        /// Used in <see cref="GridSystem.Grid.Check(GridSystem.Coord)"/>.
        /// </summary>
        public const string NoSafeDirections = "You cannot safely move in any direction. Abort mission.";

        /// <summary>
        /// The message when the agent is already at the objective.
        /// Used in <see cref="GridSystem.Grid.Path(GridSystem.Coord, GridSystem.Coord)"/>.
        /// </summary>
        public const string SameCoords = "Agent, you are already at the objective.";

        /// <summary>
        /// The message when the objective is not safe.
        /// Used in <see cref="GridSystem.Grid.Path(GridSystem.Coord, GridSystem.Coord)"/>.
        /// </summary>
        public const string ObjectiveNotSafe = "The objective is blocked by an obstacle and cannot be reached.";

        /// <summary>
        /// The message when there are is no safe path to the objective.
        /// Used in <see cref="GridSystem.Grid.Path(GridSystem.Coord, GridSystem.Coord)"/>.
        /// </summary>
        public const string NoSafePath = "There is no safe path to the objective.";

        /* Command-related messages */
        /// <summary>
        /// The message when the number of arguments does not match the expected count.
        /// Used in <see cref="ArgumentHelper.CompareArgsCount(string[], int)"/>.
        /// Intended to be the error message of <see cref="CustomExceptions.IncorrectNumberOfArgumentsException"/>.
        /// </summary>
        public const string IncorrectNumberOfArgs = "Incorrect number of arguments.";

        /// <summary>
        /// The message when the raw input of an obstacle type is invalid.
        /// Used to define the command tree in <see cref="GridSystem.Program"/>.
        /// </summary>
        public const string InvalidObstacle = "Invalid obstacle type.";

        /// <summary>
        /// The message when an obstacle type is not specified.
        /// Used to define the command tree in <see cref="GridSystem.Program"/>.
        /// </summary>
        public const string UnspecifiedObstacle = "You need to specify an obstacle type.";

        /// <summary>
        /// The message when the first word (command key) is invalid and also prompts to type 'help'.
        /// Used to define the command tree in <see cref="GridSystem.Program"/>.
        /// </summary>
        public const string InvalidOption = "Invalid option: {0}\nType 'help' to see a list of commands.";

        /* Default Command-related messages */

        /// <summary>
        /// The default message when the command key is unspecified.
        /// </summary>
        public const string DefaultUnspecifiedCommandKey = "A command key must be specified.";

        /// <summary>
        /// The default message when the command key is invalid.
        /// </summary>
        public const string DefaultInvalidCommandKey = "Invalid command key: {0}.";

        /// <summary>
        /// The default message when the <see cref="GridSystem.ObstacleType"/> enum is invalid.
        /// </summary>
        public const string DefaultInvalidObstacleEnum = "Invalid ObstacleType enum.";

        /// <summary>
        /// Throws a <see cref="NotImplementedException"/> with a message indicating that the execute action at the leaf command is missing.
        /// </summary>
        /// <param name="args">The arguments used by the execute action.</param>
        /// <exception cref="NotImplementedException">Thrown when the execute function at leaf command is missing.</exception>
        public static void EmptyExecute(string[] args)
        {
            throw new NotImplementedException("Missing execute action at leaf command.");
        }
    }
}
