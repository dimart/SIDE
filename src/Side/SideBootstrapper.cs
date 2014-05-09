using System.Windows;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

using Side.Interfaces;
using Side.Interfaces.Services;
using Side.Core;

namespace Side
{
    class SideBootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IShell, ShellView>(new ContainerControlledLifetimeManager());
        }

        protected override DependencyObject CreateShell()
        {
            return (DependencyObject) Container.Resolve<IShell>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window) Shell;
            (Shell as Window).Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @".\" };
        }

        protected override void InitializeModules()
        {
            IModule coreModule = Container.Resolve<CoreModule>();
            coreModule.Initialize();

            base.InitializeModules();
        }
    }
}
