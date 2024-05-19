namespace CommandValidation
{
    public class Command
    {
        public ArgType[]? Arguments { get; }
        public Dictionary<string, Command>? SubCommands { get; }
        public Action<string[]>? Execute { get; }
        public string ArgCountErrorMsg { get; } = "Incorrect number of arguments.";
        public string InvalidKeyErrorMsg { get; } = "Invalid option: {0}";
        public string NoKeyGivenErrorMsg { get; } = "No key is given.";
        private const string DEFAULT_ARG_COUNT = "Incorrect number of arguments.";
        private const string DEFAULT_INVALID_KEY = "Invalid option: {0}";
        private const string DEFAULT_NO_KEY_GIVEN = "No key is given.";

        // TODO: Think on how to create the constructors when Execute() is now a thing. Done ✅

        // No Arguments
        public Command(Action<string[]> execute)
        {
            Arguments = Array.Empty<ArgType>();
            Execute = execute;
        }

        // Only Arguments
        public Command(Action<string[]> execute, params ArgType[] arguments) : this(execute)
        {
            Arguments = arguments;
        }

        // Arguments with an argCountErrorMsg
        public Command(Action<string[]> execute, string argCountErrorMsg = DEFAULT_ARG_COUNT, params ArgType[] arguments) : this(execute, arguments)
        {
            ArgCountErrorMsg = argCountErrorMsg;
        }

        // Only SubCommands
        public Command(Dictionary<string, Command> subCommands)
        {
            SubCommands = subCommands;
        }

        // SubCommands with invalidKey and noKeyGiven error message
        public Command(Dictionary<string, Command> subCommands, string invalidKeyErrorMsg = DEFAULT_INVALID_KEY, string noKeyErrorMsg = DEFAULT_NO_KEY_GIVEN) : this(subCommands)
        {
            InvalidKeyErrorMsg = invalidKeyErrorMsg;
            NoKeyGivenErrorMsg = noKeyErrorMsg;
        }
    }
}

