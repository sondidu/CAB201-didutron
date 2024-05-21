namespace CustomExceptions
{
    /// <summary>
    /// Represents an exception that occurs when a command key is invalid.
    /// </summary>
    public class InvalidCommandKeyException : ArgumentOutOfRangeException
    {
        public new string? ActualValue { get; }

        public InvalidCommandKeyException() : base() { }

        public InvalidCommandKeyException(string? message) : base(message) { }

        public InvalidCommandKeyException(string? message,  Exception? innerException) : base(message, innerException) { }

        public InvalidCommandKeyException(string? message, string? actualValue, Exception? innerException) : base(message, innerException)
        {
            ActualValue = actualValue;
        }
    }
}
