namespace CustomExceptions
{
    /// <summary>
    /// Represents an exception that occurs when an argument cannot be parsed to a int.
    /// </summary>
    public class IntArgumentException : ArgumentException
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="IntArgumentException"/> class.
        /// </summary>
        public IntArgumentException() : base() { }

        /// <summary>
        /// Initialises a new instance of the <see cref="IntArgumentException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains why the int is invalid.</param>
        public IntArgumentException(string? message) : base(message) { }

        /// <summary>
        /// Initialises a new instance of the <see cref="IntArgumentException"/> class with a specified error message and inner exception.
        /// </summary>
        /// <param name="message">The error message that explains why the int is invalid.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public IntArgumentException(string? message, Exception? innerException) : base(message, innerException) { }

        /// <summary>
        /// Initialises a new instance of the <see cref="IntArgumentException"/> class with a specified error message, parameter name, and inner exception.
        /// </summary>
        /// <param name="message">The error message that explains why the int is invalid.</param>
        /// <param name="paramName">The parameter name that caused the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public IntArgumentException(string? message, string? paramName, Exception? innerException) : base(message, paramName, innerException) { }
    }
}
