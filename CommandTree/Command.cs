namespace CommandTree
{
    public class Command
    {
        public Dictionary<string, Command>? Children { get; }
        public Action<string[]>? Execute { get; }
        public string? UnspecifiedCommandKeyMsg { get; }
        public string? InvalidCommandKeyMsg { get; }
        private const string DEFAULT_UNSPECIFIED_COMMAND_KEY_MSG = "A command key must be sepcified.";
        private const string DEFAULT_INVALID_COMMAND_KEY_MSG = "Invalid command key: {0}.";
        public Command(Action<string[]> execute)
        {
            Execute = execute;
        }
        public Command(Dictionary<string, Command> children, string unspecifiedKeyMsg = DEFAULT_UNSPECIFIED_COMMAND_KEY_MSG, string? invalidCommandKeyMsg = DEFAULT_INVALID_COMMAND_KEY_MSG)
        {
            Children = children;
            UnspecifiedCommandKeyMsg = unspecifiedKeyMsg;
            InvalidCommandKeyMsg = invalidCommandKeyMsg;
        }
    }
}
