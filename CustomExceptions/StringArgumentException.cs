namespace CustomExceptions
{
    /// <summary>
    /// Represents an exception that occurs when a string argument is out of the expected range.
    /// </summary>
    public class StringArgumentException : ArgumentOutOfRangeException
    {
        public StringArgumentException() : base() { }

        public StringArgumentException(string? message) : base(message) { }

        public StringArgumentException(string? message, Exception? innerException) : base(message, innerException) { }

        public StringArgumentException(string? paramName, string? actualValue, string? message) : base(paramName, actualValue, message) { }
    }
}
