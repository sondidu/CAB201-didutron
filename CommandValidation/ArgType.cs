namespace CommandValidation
{
    public abstract class ArgType
    {
        public string argumentErrorMsg { get; protected set; } = "There is an invalid argument.";
        public abstract bool isValid(string argument);
    }
}
