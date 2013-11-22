﻿using System.Configuration;
using BusConductor.Application.Core;
using BusConductor.Data.Common;
using BusConductor.UI.IntegrationTests.Common;
using Lucidity.Utilities.Logging;
using StructureMap.Configuration.DSL;
using Lucidity.Utilities.Contracts.Logging;

namespace BusConductor.UI.IntegrationTests.Core
{
    public class TestRegistry : Registry
    {
        public TestRegistry()
        {
            Configure(x =>
                      {
                          x.ImportRegistry(typeof(ApplicationRegistry));
                          //For<IContextProvider>().Use<NUnitContextProvider>();
                          For<IContextProvider>().Singleton().Use<GenericContextProvider>();
                          //For<ILog>().Use<StubLog>();
                          For<ILog>().Use<SqlLog>().Ctor<string>("connectionString").Is(ConfigurationManager.ConnectionStrings["BusConductor"].ConnectionString);
                      });

        }
    }
}
