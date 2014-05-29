using System;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Side.Core.CodeBox;
using Side.Interfaces;
using Side.Interfaces.Events;
using Side.Interfaces.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using Xceed.Wpf.AvalonDock;

namespace Side
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : IShell
    {
        private readonly IUnityContainer _container;
        private readonly IEventAggregator _eventAggregator;
        private ILoggerService _logger;

        public ShellView(IUnityContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;
            InitializeComponent();
        }

        private void dockManager_ActiveContentChanged(object sender, EventArgs e)
        {
            var manager = (DockingManager) sender;
            var cvm = (CodeViewModel) manager.ActiveContent;
            _eventAggregator.GetEvent<ActiveContentChangedEvent>().Publish(cvm);
            if (cvm != null) Logger.Log(string.Format("Active document changed to {0}", cvm.Title), LogCategory.Info, LogPriority.Low);
        }

        private ILoggerService Logger
        {
            get { return _logger ?? (_logger = _container.Resolve<ILoggerService>()); }
        }
    }
}
