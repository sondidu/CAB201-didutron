using ConstantsAndHelpers;

namespace CommandTree
{
    /// <summary>
    /// Represents a command node in a command tree.
    /// </summary>
    public class Command
    {
        /// <summary>
        /// The children of the command.
        /// </summary>
        public Dictionary<string, Command>? Children { get; }

        /// <summary>
        /// The action to be executed.
        /// </summary>
        public Action<string[]> Execute { get; } = ErrorMessage.EmptyExecute;

        /// <summary>
        /// The error message of an unspecified command key.
        /// </summary>
        public string? UnspecifiedCommandKeyMsg { get; }

        /// <summary>
        /// The error message of an invalid command key.
        /// </summary>
        public string? InvalidCommandKeyMsg { get; }

        /// <summary>
        /// Initialises a new instance of the <see cref="Command"/> class where this command is a leaf.
        /// </summary>
        /// <param name="execute">The action to be executed.</param>
        public Command(Action<string[]> execute)
        {
            Execute = execute;
        }

        /// <summary>
        /// Initialises a new instace of the <see cref="Command"/> class where this command has children.
        /// </summary>
        /// <param name="children">The child commands.</param>
        /// <param name="invalidCommandKeyMsg">The error message of an invalid command key.</param>
        /// <param name="unspecifiedCommandKeyMsg">The error message of an unspecified command key.</param>
        public Command(Dictionary<string, Command> children, string invalidCommandKeyMsg = ErrorMessage.DefaultInvalidCommandKey, string unspecifiedCommandKeyMsg = ErrorMessage.DefaultUnspecifiedCommandKey)
        {
            Children = children;
            InvalidCommandKeyMsg = invalidCommandKeyMsg;
            UnspecifiedCommandKeyMsg = unspecifiedCommandKeyMsg;
        }
    }
}
