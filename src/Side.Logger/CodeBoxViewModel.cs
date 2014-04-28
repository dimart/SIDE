using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;

using System.ComponentModel;

using Side.Interfaces;
using Side.Interfaces.Events;
using Side.Interfaces.Services;

namespace Side.CodeBox
{
    internal class CodeBoxViewModel
    {
        private readonly IEventAggregator _aggregator;
        private readonly IUnityContainer _container;
        private readonly CodeBoxView _view;
        private readonly CodeBoxModel _model;
        private IWorkspace _workspace;

        public virtual event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; protected set; }

        private ViewModelBase Model { get; set; }
        
        private bool _isVisible = true;
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (_isVisible != value)
                {
                    _isVisible = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("IsVisible"));
                }
            }
        }

        public CodeBoxViewModel(IUnityContainer container, AbstractWorkspace workspace)
        {
            _workspace = workspace;
            _container = container;
            Name = "CodeBox";
            
            IsVisible = false;

            _model = new CodeBoxModel();

            _view = new CodeBoxView();
            _view.DataContext = _model;

            _aggregator = _container.Resolve<IEventAggregator>();
        }
    }
}
