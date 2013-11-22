using System.Windows;
using BusConductor.Admin.UI.Core;
using BusConductor.Admin.UI.Test;
using StructureMap;

namespace BusConductor.Admin.UI
{
    public partial class App : System.Windows.Application
    {
        public App()
        {
            ObjectFactory.Container.Configure(x => x.AddRegistry<UiRegistry>());


            var td1 = ObjectFactory.GetInstance<ITestDependency>();
            var td2 = ObjectFactory.GetInstance<ITestDependency>();
            var td3 = ObjectFactory.GetInstance<ITestDependency>();

            td1 = null;

            var td4 = ObjectFactory.GetInstance<ITestDependency>();
            var td5= ObjectFactory.GetInstance<ITestDependency>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }
}
