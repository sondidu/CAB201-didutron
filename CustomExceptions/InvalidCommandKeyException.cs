namespace CustomExceptions
{
    /// <summary>
    /// Represents an exception that occurs when a command key is invalid in a command node that has children.
    /// </summary>
    public class InvalidCommandKeyException : ArgumentOutOfRangeException
    {
        /// <summary>
        /// Gets the actual value that caused the exception.
        /// </summary>
        public new string? ActualValue { get; }

        /// <summary>
        /// Initialises a new instance of the <see cref="InvalidCommandKeyException"/> class.
        /// </summary>
        public InvalidCommandKeyException() : base() { }

        /// <summary>
        /// Initialises a new instance of the <see cref="InvalidCommandKeyException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains why the command key is invalid.</param>
        public InvalidCommandKeyException(string? message) : base(message) { }

        /// <summary>
        /// Initialises a new instance of the <see cref="InvalidCommandKeyException"/> class with a specified error message and inner exception.
        /// </summary>
        /// <param name="message">The error message that explains why the command key is invalid.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidCommandKeyException(string? message,  Exception? innerException) : base(message, innerException) { }

        /// <summary>
        /// Initialises a new instance of the <see cref="InvalidCommandKeyException"/> class with a specified error message, actual value, and inner exception.
        /// </summary>
        /// <param name="message">The error message that explains why the command key is invalid.</param>
        /// <param name="actualValue">The actual value that caused the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidCommandKeyException(string? message, string? actualValue, Exception? innerException) : base(message, innerException)
        {
            ActualValue = actualValue;
        }
    }
}
