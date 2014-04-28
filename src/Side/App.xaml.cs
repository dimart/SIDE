using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.Practices.Unity;

namespace Side
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private SideBootstrapper b;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            b = new SideBootstrapper();
            b.Run();
        }
    }
}
