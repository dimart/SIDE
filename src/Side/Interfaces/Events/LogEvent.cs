using Microsoft.Practices.Prism.Events;
using Side.Interfaces.Services;

namespace Side.Interfaces.Events
{
    /// <summary>
    /// This event is used when some logging operation happens.
    /// </summary>
    public class LogEvent : CompositePresentationEvent<ILoggerService>
    {
    }
}
