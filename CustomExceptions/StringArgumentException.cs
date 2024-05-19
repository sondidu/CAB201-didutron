namespace CustomExceptions
{
    public class StringArgumentException : ArgumentException
    {
        public StringArgumentException() : base() { }
        public StringArgumentException(string? message) : base(message) { }
        public StringArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
        public StringArgumentException(string? message, string? paramName, Exception? innerException) : base(message, paramName, innerException) { }
    }
}
