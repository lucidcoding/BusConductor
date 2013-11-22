using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using BusConductor.Data.Common;
using BusConductor.Application.Core;
using BusConductor.UI.ActionFilters;
using BusConductor.UI.Common;
using Lucidity.Utilities.Contracts.Logging;
using Lucidity.Utilities.Logging;
using StructureMap.Configuration.DSL;
//using HttpContextProvider = BusConductor.UI.Common.HttpContextProvider;

namespace BusConductor.UI.Core
{
    public class UiRegistry : Registry
    {
        public UiRegistry()
        {
            Configure(x =>
                      {
                          x.ImportRegistry(typeof(ApplicationRegistry));
                          //For<IContextProvider>().Use<HttpContextProvider>();

                          For<IContextProvider>().HttpContextScoped().Use<GenericContextProvider>();

                          For<ILog>().Use<SqlLog>().Ctor<string>("connectionString").Is(ConfigurationManager.ConnectionStrings["BusConductor"].ConnectionString);
                          For<IActionInvoker>().Use<InjectingActionInvoker>();
                          For<ITempDataProvider>().Use<SessionStateTempDataProvider>();
                          For<RouteCollection>().Use(RouteTable.Routes);

                          SetAllProperties(c =>
                          {
                              c.OfType<IActionInvoker>();
                              c.OfType<ITempDataProvider>();
                              c.WithAnyTypeFromNamespaceContainingType<LogAttribute>();
                          });
                      });

        }
    }
}