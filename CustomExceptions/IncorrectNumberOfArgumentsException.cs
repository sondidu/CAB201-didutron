namespace CustomExceptions
{
    public class IncorrectNumberOfArgumentsException : ArgumentException
    {
        public IncorrectNumberOfArgumentsException() : base() { }
        public IncorrectNumberOfArgumentsException(string? message) : base(message) { }
        public IncorrectNumberOfArgumentsException(string? message, Exception? innerException) : base(message, innerException) { }
        public IncorrectNumberOfArgumentsException(string? message, string? paramName, Exception? innerException) : base(message, paramName, innerException) { }
    }
}
