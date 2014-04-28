using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;

using Side.Interfaces.Events;
using Side.Interfaces.Services;

namespace Side.Interfaces
{
    public abstract class AbstractWorkspace : ViewModelBase, IWorkspace
    {
        protected readonly IUnityContainer m_container;
        protected readonly IEventAggregator m_eventAggregator;
        private ContentViewModel m_activeDocument;

        #region CTOR

        protected AbstractWorkspace(IUnityContainer container, IEventAggregator eventAggregator)
        {
            m_container = container;
            m_eventAggregator = eventAggregator;
        }

        #endregion

        #region IWorkspace Members

        public virtual string Title
        {
            get { return "Simple IDE"; }
        }

        #endregion
    }
}
