using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.Practices.Unity;

using Side.Interfaces;

namespace SIDE
{
    public partial class App : Application
    {
        private Bootstrapper bootstrapper;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            bootstrapper = new Bootstrapper();
            bootstrapper.Run();
            var shell = bootstrapper.Container.Resolve<IShell>();
            (shell as Window).Loaded += App_Loaded;
            (shell as Window).Unloaded += App_Unloaded;
        }

        void App_Unloaded(object sender, System.EventArgs e)
        {
            var shell = bootstrapper.Container.Resolve<IShell>();
            shell.SaveLayout();
        }

        void App_Loaded(object sender, RoutedEventArgs e)
        {
            var shell = bootstrapper.Container.Resolve<IShell>();
            shell.LoadLayout();
        }
    }
}
