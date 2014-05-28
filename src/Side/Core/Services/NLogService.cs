using System.Diagnostics;
using System.Reflection;

using Microsoft.Practices.Prism.Events;
using NLog;

using Side.Interfaces.Services;
using Side.Interfaces.Events;

namespace Side.Core.Services
{
    public class NLogService : ILoggerService
    {
        private static readonly Logger Logger = LogManager.GetLogger("Side");
        private readonly IEventAggregator _aggregator;

        private NLogService()
        {
        }

        public NLogService(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        #region ILoggerService Members

        public void Log(string message, LogCategory category, LogPriority priority)
        {
            Message = message;
            Category = category;
            Priority = priority;

            var trace = new StackTrace();
            StackFrame frame = trace.GetFrame(1);
            MethodBase method = frame.GetMethod();

            Logger.Log(LogLevel.Info, method.DeclaringType + ": " + message);

            _aggregator.GetEvent<LogEvent>().Publish(new NLogService { Message = Message, Category = Category, Priority = Priority });
        }

        /// <summary>
        /// The last logged message 
        /// </summary>
        public string Message { get; internal set; }

        public LogCategory Category { get; internal set; }
        public LogPriority Priority { get; internal set; }

        #endregion
    }
}
