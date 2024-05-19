namespace CustomExceptions
{
    public class DoubleArgumentException : ArgumentException
    {
        public DoubleArgumentException () : base() { }
        public DoubleArgumentException (string message) : base(message) { }
        public DoubleArgumentException (string message, Exception innerException) : base(message, innerException) { }
    }
}
