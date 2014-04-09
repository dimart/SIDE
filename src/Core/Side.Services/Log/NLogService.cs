using System.Diagnostics;
using System.Reflection;

using NLog;

using Side.Interfaces.Services;

namespace Side.Services.Log
{
    class NLogService : ILogService
    {
        private static readonly Logger Logger = LogManager.GetLogger("Side");

        private NLogService()
        {
        }

        #region ILogService Members
        public void Log(string message, LogCategory category, LogPriority priority)
        {
            Message = message;
            Category = category;
            Priority = priority;

            var trace = new StackTrace();
            StackFrame frame = trace.GetFrame(1);
            MethodBase method = frame.GetMethod();

            Logger.Log(LogLevel.Info, method.DeclaringType + ": " + message);
        }

        /// <summary>
        /// The message which was last logged using the service
        /// </summary>
        public string Message { get; private set; }

        public LogCategory Category { get; private set; }
        public LogPriority Priority { get; private set; }
        #endregion
    }
}
