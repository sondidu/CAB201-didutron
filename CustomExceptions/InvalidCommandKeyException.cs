namespace CustomExceptions
{
    public class InvalidCommandKeyException : ArgumentException
    {
        public new string? ParamName { get; }
        public InvalidCommandKeyException() : base() { }
        public InvalidCommandKeyException(string? message) : base(message) { }
        public InvalidCommandKeyException(string? message,  Exception? innerException) : base(message, innerException) { }
        public InvalidCommandKeyException(string? message, string? paramName, Exception? innerException): base(message, innerException)
        {
            ParamName = paramName;
        }
    }
}
