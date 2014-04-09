using System.Windows;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

using Side.Services;
using Side.Interfaces;

namespace Side.Shell
{
    public class SideBootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IShell, ShellView>(new ContainerControlledLifetimeManager());
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            (Shell as Window).Show();
        }

        protected override DependencyObject CreateShell()
        {
            return (DependencyObject) Container.Resolve<IShell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window) Shell;
        }
    }
}
