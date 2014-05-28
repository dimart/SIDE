using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Side.Core.CodeBox;
using Side.Interfaces;
using Side.Interfaces.Services;

namespace Side.Core
{
    class Workspace : IWorkspace
    {
        private IUnityContainer _container;
        private IEventAggregator _eventAggregator;
        private ILoggerService _logger;

        private ObservableCollection<CodeViewModel> _docs = new ObservableCollection<CodeViewModel>();
        private CodeViewModel _activeDocument;

        private string _document;
        private const string _title = "Simple IDE";
        
        #region CTOR

        public Workspace(IUnityContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;
            _document = "";
        }

        #endregion

        #region IWorkspace Members

        public ObservableCollection<CodeViewModel> Documents
        {
            get { return _docs; }
            set { _docs = value; }
        }

        public CodeViewModel ActiveDocument { get; set; }

        public string Title
        {
            get
            {
                string newTitle = _title;
                if (_document != "")
                {
                    newTitle += " - " + _document;
                }
                return newTitle;
            }
        }

        #endregion

        private ILoggerService Logger
        {
            get { return _logger ?? (_logger = _container.Resolve<ILoggerService>()); }
        }
    }
}
