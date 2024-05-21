namespace CustomExceptions
{
    /// <summary>
    /// Represents an exception that occurs when an argument cannot be parsed to a double.
    /// </summary>
    public class DoubleArgumentException : ArgumentException
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DoubleArgumentException"/> class.
        /// </summary>
        public DoubleArgumentException() : base() { }

        /// <summary>
        /// Initialises a new instance of the <see cref="DoubleArgumentException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains why the double is invalid.</param>
        public DoubleArgumentException(string? message) : base(message) { }

        /// <summary>
        /// Initialises a new instance of the <see cref="DoubleArgumentException"/> class with a specified error message and inner exception.
        /// </summary>
        /// <param name="message">The error message that explains why the double is invalid.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public DoubleArgumentException(string? message, Exception? innerException) : base(message, innerException) { }

        /// <summary>
        /// Initialises a new instance of the <see cref="DoubleArgumentException"/> class with a specified error message and inner exception.
        /// </summary>
        /// <param name="message">The error message that explains why the double is invalid.</param>
        /// <param name="paramName">The parameter name that caused the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public DoubleArgumentException(string? message, string? paramName, Exception? innerException) : base(message, paramName, innerException) { }
    }
}
