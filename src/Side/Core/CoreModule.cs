using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

using Side.Interfaces;
using Side.Interfaces.Services;
using Side.Core.Services;

namespace Side.Core
{
    [Module(ModuleName = "Side.Core")]
    [ModuleDependency("Side.CodeBox")]
    public class CoreModule : IModule
    {
        private readonly IUnityContainer m_container;

        private IEventAggregator m_eventAggregator;
        private IEventAggregator EventAggregator
        {
            get { return m_eventAggregator; }
        }

        #region CTOR
        
        public CoreModule(IUnityContainer container, IEventAggregator eventAggregator)
        {
            m_container = container;
            m_eventAggregator = eventAggregator;
        }

        #endregion

        #region IModule

        public void Initialize()
        {
            m_container.RegisterType<AbstractWorkspace, Workspace>(new ContainerControlledLifetimeManager());
            m_container.RegisterType<ILoggerService, NLogService>(new ContainerControlledLifetimeManager());
        }

        #endregion
    }
}
