namespace CustomExceptions
{
    /// <summary>
    /// Represents an exception that occurs when the number of arguments provided does not match.
    /// </summary>
    public class IncorrectNumberOfArgumentsException : Exception
    {
        /// <summary>
        /// Gets the expected number of arguments.
        /// </summary>
        public int ExpectedNumberOfArguments { get; }

        /// <summary>
        /// Initialises a new instance of the <see cref="IncorrectNumberOfArgumentsException"/> class with a specified error message and expeced number of arguments.
        /// </summary>
        /// <param name="message">The error message that explains why the number of arguments are incorrect.</param>
        /// <param name="expectedNumberOfArguments">The expected number of arguments.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="expectedNumberOfArguments"/> is less than 0.</exception>
        public IncorrectNumberOfArgumentsException(string? message, int expectedNumberOfArguments) : this(message, expectedNumberOfArguments, null) { }

        /// <summary>
        /// Initialises a new instance of the <see cref="IncorrectNumberOfArgumentsException"/> class with a specified error message, expeced number of arguments, and inner exception.
        /// </summary>
        /// <param name="message">The error message that explains why the number of arguments are incorrect.</param>
        /// <param name="expectedNumberOfArguments">The expected number of arguments.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="expectedNumberOfArguments"/> is less than 0.</exception>
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
