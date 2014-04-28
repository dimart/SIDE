using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;

using Side.Interfaces;
using Side.Interfaces.Services;

namespace Side.Core
{
    class Workspace : AbstractWorkspace
    {
        private string m_document;
        private ILoggerService m_logger;
        private const string m_title = "Simple IDE";
        
        public Workspace(IUnityContainer container, IEventAggregator eventAggregator)
            : base(container, eventAggregator)
        {
            m_document = "";
        }

        public override string Title
        {
            get
            {
                string newTitle = m_title;
                if (m_document != "")
                {
                    newTitle += " - " + m_document;
                }
                return newTitle;
            }
        }

        private ILoggerService Logger
        {
            get
            {
                if (m_logger == null)
                    m_logger = m_container.Resolve<ILoggerService>();
                return m_logger;
            }
        }
    }
}
