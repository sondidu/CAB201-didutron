namespace CommandValidation
{
    public class CommandValidator
    {
        private Command commands;
        private string currentCommand;
        public string CurrentCommand
        {
            get
            {
                return currentCommand;
            }

            set
            {
                currentCommand = value.Trim();
            }
        }

        // Passes a Dictionary<string, Command>
        public CommandValidator(Dictionary<string, Command> commands)
        {
            this.commands = new Command(commands);
            currentCommand = "";
        }
        // Passes a Command
        public CommandValidator(Command commands)
        {
            this.commands = commands;
            currentCommand = "";
        }

        private void Validate()
        {
            string[] parts = CurrentCommand.Split(' ');

            int wordIndex = 0;
            var command = commands;

            // Iterate every word until command is no longer a dictionary or has iterated all of the words
            while (command.SubCommands != null && wordIndex < parts.Length)
            {
                if (!command.SubCommands.ContainsKey(parts[wordIndex]))
                {
                    string errorMsg = string.Format(command.InvalidKeyErrorMsg, parts[wordIndex]);
                    throw new Exception(errorMsg);
                }

                command = command.SubCommands[parts[wordIndex++]];
            }

            // `command` never reached a state where it has only arguments.
            // That means command has subcommands (aka no arguments) and the .ContainsKey() method was never called in the
            // while loop due to the loop being stopped by wordIndex that is now greater than or equal to parts.Length.
            if (command.Arguments == null)
            {
                throw new Exception(command.NoKeyGivenErrorMsg);
            }

            // At this stage, we have reached a Command where it has Arguments and no SubCommands.
            var arguments = command.Arguments; 
            if (parts.Length - wordIndex != arguments.Length)
            {
                throw new Exception(command.ArgCountErrorMsg);
            }

            // Compare all the arguments (the remaining words) to see if they all have the correct type.
            for (int i = 0; i < arguments.Length; i++)
            {
                if (!arguments[i].isValid(parts[wordIndex + i]))
                {
                    string errorMsg = arguments[i].argumentErrorMsg;
                    throw new Exception(errorMsg);
                }
            }
        }

        private string[] GetArgs()
        {
            string[] parts = CurrentCommand.Split(' ');
            int wordIndex = 0;
            var command = commands;

            // Since we know the command is valid, we don't need to worry that the word index is gonna reach beyond parts.Length
            while (command.SubCommands != null)
            {
                string word = parts[wordIndex];
                command = command.SubCommands[word];
                wordIndex++;
            }

            int argsCount = parts.Length - wordIndex;
            string[] args = new string[argsCount];
            Array.Copy(parts, wordIndex, args, 0, argsCount);

            return args;
        }

        private Command GetCommand()
        {
            string[] parts = CurrentCommand.Split(' ');
            int wordIndex = 0;
            var command = commands;
            while (command.SubCommands != null)
            {
                string word = parts[wordIndex];
                command = command.SubCommands[word];
                wordIndex++;
            }

            return command;
        }

        public void TryRun()
        {
            try
            {
                Validate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            string[] args = GetArgs();
            Command command = GetCommand();
            command.Execute(args);
        }
    }
}
