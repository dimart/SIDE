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

        protected IWorkspace     _workspace;
        protected ILoggerService _logger;
        protected string _title = null;
        
        #endregion

        #region CTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentViewModel"/> class.
        /// </summary>
        /// <param name="workspace">The injected workspace.</param>
        /// <param name="logger">The injected logger.</param>
        protected ContentViewModel(IWorkspace workspace, ILoggerService logger)
        {
            _workspace = workspace;
            _logger = logger;
        }

        #endregion
    }
}
