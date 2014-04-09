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

    public interface ILogService
    {
        string Message { get; }
        LogCategory Category { get; }
        LogPriority Priority { get; }

        void Log(string message, LogCategory category, LogPriority priority);
    }
}
