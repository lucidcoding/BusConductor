using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using BusConductor.Application.Core;
using BusConductor.Data.Common;
using BusConductor.Data.Repositories;
using BusConductor.Domain.RepositoryContracts;
using Lucidity.Utilities.Contracts.Logging;
using Lucidity.Utilities.Logging;
using StructureMap.Configuration.DSL;
using BusConductor.Admin.UI.ViewModels.Bus;

namespace BusConductor.Admin.UI.Core
{
    public class UiRegistry : Registry
    {
        public UiRegistry()
        {
            Configure(x =>
            {
                x.ImportRegistry(typeof(ApplicationRegistry));
                //For<IContextProvider>().Use<HttpContextProvider>();

                //todo: change back
                //For<ILog>().Use<SqlLog>().Ctor<string>("connectionString").Is(ConfigurationManager.ConnectionStrings["BusConductor"].ConnectionString);
                //For<ILog>().Use<SqlLog>().Ctor<string>("test");


  
                For<IContextProvider>().Use<StubContextProvider>();
                For<ILog>().Use<StubLog>();


                //For<IActionInvoker>().Use<InjectingActionInvoker>();
                //For<ITempDataProvider>().Use<SessionStateTempDataProvider>();
                //For<RouteCollection>().Use(RouteTable.Routes);

                //SetAllProperties(c =>
                //{
                //    c.OfType<IBusRepository>();
                //    c.WithAnyTypeFromNamespaceContainingType<IndexViewModel>();
                //});

                SetAllProperties(y => y.OfType<IBusRepository>());

                //ForConcreteType<IndexViewModel>()
                //    .Configure
                //    .Setter<IBusRepository>(y => y.BusRepository)
                //    .IsTheDefault();
            });

        }
    }
}
