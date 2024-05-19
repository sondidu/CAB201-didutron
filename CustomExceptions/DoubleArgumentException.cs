namespace CustomExceptions
{
    public class DoubleArgumentException : ArgumentException
    {
        public DoubleArgumentException() : base() { }
        public DoubleArgumentException(string? message) : base(message) { }
        public DoubleArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
        public DoubleArgumentException(string? message, string? paramName, Exception? innerException) : base(message, paramName, innerException) { }
    }
}
