namespace CustomExceptions
{
    public class InvalidCommandKeyException : ArgumentException
    {
        public InvalidCommandKeyException() : base() { }
        public InvalidCommandKeyException(string? message) : base(message) { }
        public InvalidCommandKeyException(string? message,  Exception? innerException) : base(message, innerException) { }
        public InvalidCommandKeyException(string? message, string? paramName, Exception? innerException): base(message, paramName, innerException) { }
    }
}
