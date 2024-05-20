using ConstantsAndHelpers;
using CustomExceptions;
namespace CommandTree
{
    public class Runner
    {
        private readonly Command Commands;
        public Runner(Command commands)
        {
            Commands = commands;
        }
        private void Run(string input)
        {
            Command commandIterator = Commands;
            string[] parts = input.Split(' ');
            int wordIdx = 0;

            try
            {
                while (commandIterator.Children != null)
                {
                    string currentArg = parts[wordIdx];
                    commandIterator = commandIterator.Children[currentArg];
                    wordIdx++;
                }
            }
            catch(IndexOutOfRangeException ex)
            {
                throw new UnspecifiedCommandKeyException(commandIterator.UnspecifiedCommandKeyMsg, ex);
            }
            catch(KeyNotFoundException ex)
            {
                throw new InvalidCommandKeyException(commandIterator.InvalidCommandKeyMsg, parts[wordIdx], ex);
            }

            // Copying the arguments in `parts` to `args`
            int argCount = parts.Length - wordIdx;
            string[] args = new string[argCount];
            Array.Copy(parts, wordIdx, args, 0, argCount);

            Action<string[]> execute = commandIterator.Execute;

            execute(args);
        }
        public bool TryRun(string? input, out string message)
        {
            input ??= ""; // If null, convert to empty string
            try
            {
                Run(input);
            }
            catch(InvalidCommandKeyException ex)
            {
                message = string.Format(ex.Message, ex.ParamName);
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
            catch(Exception ex)
            {
                message = ex.Message;
                return false;
            }

            message = "";
            return true;
        }

    }
}
