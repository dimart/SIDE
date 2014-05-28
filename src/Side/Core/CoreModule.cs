using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Side.Core.CodeBox;
using Side.Interfaces;
using Side.Interfaces.Services;
using Side.Core.Services;

namespace Side.Core
{
    [Module(ModuleName = "Side.Core")]
    [ModuleDependency("Side.CodeBox")]
    public class CoreModule : IModule
    {
        private readonly IUnityContainer _container;

        private IEventAggregator _eventAggregator;
        private IEventAggregator EventAggregator
        {
            get { return _eventAggregator; }
        }

        #region CTOR
        
        public CoreModule(IUnityContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;
        }

        #endregion

        #region IModule

        public void Initialize()
        {
            _container.RegisterType<IWorkspace, Workspace>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ILoggerService, NLogService>(new ContainerControlledLifetimeManager());
            
            _container.RegisterType<CodeModel>();
            _container.RegisterType<CodeView>();
            _container.RegisterType<CodeViewModel>();
        }

        #endregion
    }
}
