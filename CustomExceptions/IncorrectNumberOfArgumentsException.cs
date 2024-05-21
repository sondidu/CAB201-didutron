namespace CustomExceptions
{
    /// <summary>
    /// Represents an exception that occurs when the number of arguments provided does not match.
    /// </summary>
    public class IncorrectNumberOfArgumentsException : Exception
    {
        public int ExpectedNumberOfArguments { get; private set; }

        public IncorrectNumberOfArgumentsException(string? message, int expectedNumberOfArguments) : this(message, expectedNumberOfArguments, null) { }

        public IncorrectNumberOfArgumentsException(string? message, int expectedNumberOfArguments, Exception? innerException) : base(message, innerException)
        {
            if (expectedNumberOfArguments < 0)
            {
                throw new ArgumentException("Expected number of arguments should be a positive number.");
            }
            ExpectedNumberOfArguments = expectedNumberOfArguments;
        }
    }
}
