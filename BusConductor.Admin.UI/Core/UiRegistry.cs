using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using BusConductor.Admin.UI.Common;
using BusConductor.Admin.UI.Test;
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

                //http://msdn.microsoft.com/en-us/magazine/ee819139.aspx
                //http://stackoverflow.com/questions/7177017/wpf-mvvm-nhibernate-a-simple-example

                x.ImportRegistry(typeof(ApplicationRegistry));

                For<ITestDependency>().HybridHttpOrThreadLocalScoped().Use<TestDependency>();

                //todo: change back
                //For<ILog>().Use<SqlLog>().Ctor<string>("connectionString").Is(ConfigurationManager.ConnectionStrings["BusConductor"].ConnectionString);
                //For<ILog>().Use<SqlLog>().Ctor<string>("test");
                For<INavigationService>().Use<NavigationService>();

                For<IContextProvider>().Use<StubContextProvider>();
                For<ILog>().Use<StubLog>();
            });

        }
    }
}
