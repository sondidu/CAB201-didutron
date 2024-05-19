namespace CustomExceptions
{
    public class IntArgumentException : ArgumentException
    {
        public IntArgumentException() : base() { }
        public IntArgumentException(string message) : base(message) { }
        public IntArgumentException(string message, Exception innerException) : base(message, innerException) { }
    }
}
