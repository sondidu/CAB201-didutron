using ConstantsAndHelpers;
using CustomExceptions;

namespace CommandTree
{
    /// <summary>
    /// Runner class that executes commands.
    /// </summary>
    public class Runner
    {
        private readonly Command Commands;

        /// <summary>
        /// Initialises a new instance of the <see cref="Runner"/> class.
        /// </summary>
        /// <param name="commands">The commands to be executed.</param>
        public Runner(Command commands)
        {
            Commands = commands;
        }

        /// <summary>
        /// Executes the given input command.
        /// </summary>
        /// <param name="input">The input command to be executed.</param>
        /// <exception cref="UnspecifiedCommandKeyException">Thrown when the command key is not specified.</exception>
        /// <exception cref="InvalidCommandKeyException">Thrown when the command key is invalid.</exception>
        private void Run(string input)
        {
            Command commandIterator = Commands;
            string[] parts = input.Split(' ');
            int partIdx = 0;

            try
            {
                // Iterate command tree until it reaches a command leaf
                while (commandIterator.Children != null)
                {
                    string currentArg = parts[partIdx];
                    commandIterator = commandIterator.Children[currentArg];
                    partIdx++;
                }
            }
            catch(IndexOutOfRangeException ex) // Caught when partIdx > parts.Length
            {
                throw new UnspecifiedCommandKeyException(commandIterator.UnspecifiedCommandKeyMsg, ex);
            }
            catch(KeyNotFoundException ex) // Caught when currentArg is not in commandIterator.Children.Keys
            {
                throw new InvalidCommandKeyException(commandIterator.InvalidCommandKeyMsg, parts[partIdx], ex);
            }

            // Copying the arguments in parts to args
            int argCount = parts.Length - partIdx;
            string[] args = new string[argCount];
            Array.Copy(parts, partIdx, args, 0, argCount);

            Action<string[]> execute = commandIterator.Execute;
            execute(args);
        }

        /// <summary>
        /// Tries to execute the given input command and returns a message if unsuccessful.
        /// </summary>
        /// <param name="input">The input command to be executed.</param>
        /// <param name="message">The output message if the command execution is unsuccessful.</param>
        /// <returns><c>true</c> if the command execution is successful; otherwise, <c>false</c>.</returns>
        public bool TryRun(string? input, out string message)
        {
            input ??= ""; // If null, then set to empty string
            try
            {
                Run(input);
            }
            catch(InvalidCommandKeyException ex)
            {
                message = string.Format(ex.Message, ex.ActualValue);
                return false;
            }
            catch(UnspecifiedCommandKeyException ex)
            {
                message = ex.Message;
                return false;
            }
            catch(IncorrectNumberOfArgumentsException)
            {
                message = ErrorMessage.IncorrectNumberOfArgs;
                return false;
            }
            catch(ArgumentException ex)
            {
                message = ex.Message;
                return false;
            }
            catch(Exception ex) // Unspecified error caught
            {
                message = ex.Message;
                return false;
            }

            message = "";
            return true;
        }
    }
}
