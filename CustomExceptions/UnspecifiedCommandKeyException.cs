namespace CustomExceptions
{
    /// <summary>
    /// Represents an exception that occurs when a command key is unspecified in a command node that has children.
    /// </summary>
    public class UnspecifiedCommandKeyException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="UnspecifiedCommandKeyException"/> class.
        /// </summary>
        public UnspecifiedCommandKeyException() : base() { }

        /// <summary>
        /// Initialises a new instance of the <see cref="UnspecifiedCommandKeyException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains why the command key is unspecified.</param>
        public UnspecifiedCommandKeyException(string? message) : base(message) { }

        /// <summary>
        /// Initialises a new instance of the <see cref="UnspecifiedCommandKeyException"/> class with a specified error message and inner exception.
        /// </summary>
        /// <param name="message">The error message that explains why the command key is unspecified.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public UnspecifiedCommandKeyException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
