namespace CustomExceptions
{
    /// <summary>
    /// Represents an exception that occurs when a string argument is out of the expected range.
    /// </summary>
    public class StringArgumentException : ArgumentOutOfRangeException
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="StringArgumentException"/> class.
        /// </summary>
        public StringArgumentException() : base() { }

        /// <summary>
        /// Initialises a new instance of the <see cref="StringArgumentException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains why the string argument is invalid.</param>
        public StringArgumentException(string? message) : base(message) { }

        /// <summary>
        /// Initialises a new instance of the <see cref="StringArgumentException"/> class with a specified error message and inner exception.
        /// </summary>
        /// <param name="message">The error message that explains why the string argument is invalid.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public StringArgumentException(string? message, Exception? innerException) : base(message, innerException) { }

        /// <summary>
        /// Initialises a new instance of the <see cref="StringArgumentException"/> class with a specified parameter name, actual value, and error message.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="actualValue">The actual value that caused the exception.</param>
        /// <param name="message">The error message that explains why the string argument is invalid.</param>
        public StringArgumentException(string? paramName, string? actualValue, string? message) : base(paramName, actualValue, message) { }
    }
}
