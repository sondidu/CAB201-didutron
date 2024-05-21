namespace CustomExceptions
{
    /// <summary>
    /// Represents an exception that occurs when a command key is unspecified.
    /// </summary>
    public class UnspecifiedCommandKeyException : Exception
    {
        public UnspecifiedCommandKeyException() : base() { }

        public UnspecifiedCommandKeyException(string? message) : base(message) { }

        public UnspecifiedCommandKeyException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
