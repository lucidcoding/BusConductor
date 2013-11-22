using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using BusConductor.Admin.UI.Core;
using BusConductor.Admin.UI.ViewModel;
using BusConductor.Admin.UI.ViewModels.Bus;
using BusConductor.Data.Common;
using BusConductor.Data.Repositories;
using BusConductor.Domain.RepositoryContracts;
using Lucidity.Utilities.Logging;
using StructureMap;
using Lucidity.Utilities.Contracts.Logging;

namespace BusConductor.Admin.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public App()
        {

            ObjectFactory.Container.Configure(x => x.AddRegistry<UiRegistry>());

            //ObjectFactory.Container.Configure(x => x.AddRegistry<UiRegistry>());

            //ObjectFactory.Initialize(x =>
            //                             {
            //                                 x.AddRegistry<UiRegistry>();

            //                                 x.For<IContextProvider>().Use<StubContextProvider>();
            //                                 x.For<ILog>().Use<StubLog>();
            //                                 //For<IActionInvoker>().Use<InjectingActionInvoker>();
            //                                 //For<ITempDataProvider>().Use<SessionStateTempDataProvider>();
            //                                 //For<RouteCollection>().Use(RouteTable.Routes);

            //                                 //SetAllProperties(c =>
            //                                 //{
            //                                 //    c.OfType<IActionInvoker>();
            //                                 //    c.OfType<ITempDataProvider>();
            //                                 //    c.WithAnyTypeFromNamespaceContainingType<LogAttribute>();
            //                                 //});

            //                                 //x.For<IBusRepository>().Use<BusRepository>();
            //                                 //x.FillAllPropertiesOfType<IBusRepository>();
            //                                 //x.ForConcreteType<BusConductor.Admin.UI.ViewModels.Bus.IndexViewModel>()
            //                                 //    .Configure
            //                                 //    .SetProperty(y => y.Blah = "Foo");
            //                             });

            //IViewService viewService = ServiceManager.RegisterService<IViewService>(new ViewService()); 
            //viewService.RegisterView(typeof(MainWindow), typeof(MainViewModel)); 
            //viewService.RegisterView(typeof(AboutWindow), typeof(AboutViewModel));

        }

        public void App_Startup(object sender, StartupEventArgs eventArgs)
        {
            //ContainerBootstrapper.BootstrapStructureMap();
            //ProcessStartupArguments(eventArgs);

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }
}
