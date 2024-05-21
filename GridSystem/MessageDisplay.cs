using ConstantsAndHelpers;

namespace GridSystem
{
    /// <summary>
    /// Display messages to the user.
    /// </summary>
    public static class MessageDisplay
    {
        /// <summary>
        /// Lists the available commands.
        /// </summary>
        public static void ListCommands()
        {
            ListCommands([]);
        }

        /// <summary>
        /// Lists the available commands.
        /// </summary>
        /// <param name="args">The arguments used to list the commands.</param>
        /// <exception cref="IncorrectNumberOfArgumentsException">Thrown when the number of arguments does not match the expected count.</exception>
        public static void ListCommands(string[] args)
        {
            ArgumentHelper.CompareArgsCount(args, ArgumentHelper.NoArgs);
            SuccessMessage.PrintCommands();
        }

        /// <summary>
        /// Exists the application.
        /// </summary>
        public static void Exit()
        {
            Exit([]);
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        /// <param name="args">The arguments used to exit the application.</param>
        /// <exception cref="IncorrectNumberOfArgumentsException">Thrown when the number of arguments does not match the expected count.</exception>
        public static void Exit(string[] args)
        {
            ArgumentHelper.CompareArgsCount(args, ArgumentHelper.NoArgs);
            Console.WriteLine(SuccessMessage.Exit);
        }

        /// <summary>
        /// Displays a welcome message.
        /// </summary>
        public static void Welcome()
        {
            Console.WriteLine(SuccessMessage.Welcome);
        }
    }
}
