using System;

using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

using Side.Interfaces;
using Side.Interfaces.Events;

namespace Side.CodeBox
{
    [Module(ModuleName = "Side.CodeBox")]
    public sealed class CodeBoxModule : IModule
    {
        private readonly IUnityContainer m_container;
        private readonly IRegionManager m_regionManager; 

        public CodeBoxModule(IUnityContainer container, IRegionManager regionManager)
        {
            m_regionManager = regionManager;
            m_container = container;
        }

        private IEventAggregator EventAggregator
        {
            get { return m_container.Resolve<IEventAggregator>(); }
        }

        #region IModule Members

        public void Initialize()
        {
            m_container.RegisterType<CodeBoxViewModel>();
            m_regionManager.RegisterViewWithRegion("CodeBoxRegion", typeof(CodeBoxView));
        }

        #endregion
    }
}
