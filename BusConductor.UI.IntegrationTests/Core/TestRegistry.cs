using BusConductor.Application.Core;
using BusConductor.Data.Common;
using BusConductor.UI.IntegrationTests.Common;
using StructureMap.Configuration.DSL;

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
                          For<IContextProvider>().HybridHttpOrThreadLocalScoped().Use<GenericContextProvider>();
                      });

        }
    }
}
