using Microsoft.Practices.Prism.Commands;

using Side.Interfaces.Services;

namespace Side.Interfaces
{
    /// <summary>
    /// The abstract class which has to be inherited if you want to create a document
    /// </summary>
    public abstract class ContentViewModel : ViewModelBase
    {
        #region Members

        protected IWorkspace     m_workspace;
        protected string         m_title = null;
        protected ILoggerService m_logger;

        #endregion

        #region CTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentViewModel"/> class.
        /// </summary>
        /// <param name="workspace">The injected workspace.</param>
        /// <param name="logger">The injected logger.</param>
        protected ContentViewModel(AbstractWorkspace workspace, ILoggerService logger)
        {
            m_workspace = workspace;
            m_logger = logger;
        }

        #endregion
    }
}
