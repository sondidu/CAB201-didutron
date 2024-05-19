namespace CustomExceptions
{
    public class IncorrectNumberOfArgumentsException : ArgumentException
    {
        public IncorrectNumberOfArgumentsException () : base() { }
        public IncorrectNumberOfArgumentsException (string message) : base(message) { }
        public IncorrectNumberOfArgumentsException (string message, Exception innerException) : base(message, innerException) { }
    }
}
