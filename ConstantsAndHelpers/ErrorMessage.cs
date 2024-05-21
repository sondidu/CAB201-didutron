namespace ConstantsAndHelpers
{
    /// <summary>
    /// Provides error messages.
    /// </summary>
    public static class ErrorMessage
    {
        // Functionality-related messages
        public const string InvalidCoord = "Coordinates are not valid integers.";
        public const string InvalidOrientation = "Orientation must be 'east' or 'north'.";
        public const string InvalidLength = "Length must be a valid integer greater than 0.";
        public const string InvalidRadius = "Range must be a valid positive number.";
        public const string InvalidDirection = "Direction must be 'north', 'south', 'east' or 'west'.";
        public const string InvalidMapDimensions = "Width and height must be valid positive integers.";
        public const string InvalidAgentCoord = "Agent coordinates are not valid integers.";
        public const string InvalidObjectiveCoord = "Objective coordinates are not valid integers.";
        public const string UnsafeCoord = "Agent your location is compromised. Abort mission";
        public const string NoSafeDirections = "You cannot safely move in any direction. Abort mission.";
        public const string SameCoords = "Agent, you are already at the objective.";
        public const string ObjectiveObstructed = "The objective is blocked by an obstacle and cannot be reached.";
        public const string NoSafePath = "There is no safe path to the objective.";

        // Command-related messages
        public const string IncorrectNumberOfArgs = "Incorrect number of arguments.";
        public const string InvalidObstacle = "Invalid obstacle type.";
        public const string UnspecifiedObstacle = "You need to specify an obstacle type.";
        public const string InvalidOption = "Invalid option: {0}\nType 'help' to see a list of commands.";

        // Default Command-related
        public const string DefaultInvalidNumberOfArgs = "Incorrect number of arguments. Expected {0} arguments but got {1}.";
        public const string UnspecifiedCommandKey = "A command key must be specified.";
        public const string InvalidCommandKey = "Invalid command key: {0}.";
        public const string InvalidObstacleEnum = "Invalid ObstacleType enum.";

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
