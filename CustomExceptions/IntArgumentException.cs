namespace CustomExceptions
{
    /// <summary>
    /// Represents an exception that occurs when an argument cannot be parsed to a int.
    /// </summary>
    public class IntArgumentException : ArgumentException
    {
        public IntArgumentException() : base() { }

        public IntArgumentException(string? message) : base(message) { }

        public IntArgumentException(string? message, Exception? innerException) : base(message, innerException) { }

        public IntArgumentException(string? message, string? paramName, Exception? innerException) : base(message, paramName, innerException) { }
    }
}
