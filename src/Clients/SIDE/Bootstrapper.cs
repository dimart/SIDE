using System.IO;
using System.Collections.Generic;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Side.Shell;

namespace SIDE
{
    internal class Bootstrapper : SideBootstrapper
    {
        protected override void InitializeModules()
        {
            base.InitializeModules();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @"." };    
        }
    }
}
