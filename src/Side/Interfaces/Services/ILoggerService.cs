namespace Side.Interfaces.Services
{
    public enum LogCategory
    {
        Debug,
        Exception,
        Info,
        Warn,
        Error
    }

    public enum LogPriority
    {
        None,
        Low,
        Medium,
        High
    }

    public interface ILoggerService
    {
        string Message { get; }
        LogCategory Category { get; }
        LogPriority Priority { get; }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="category">The logging category.</param>
        /// <param name="priority">The logging priority.</param>
        void Log(string message, LogCategory category, LogPriority priority);
    }
}