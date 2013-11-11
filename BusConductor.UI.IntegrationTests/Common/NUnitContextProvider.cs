using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusConductor.Data.Common;
using BusConductor.Data.Core;
using NUnit.Framework;

namespace BusConductor.UI.IntegrationTests.Common
{
    public class NUnitContextProvider : IContextProvider
    {
        public Context GetContext()
        {
            if (TestContext.CurrentContext.Test.Properties["Context"] == null)
            {
                throw new Exception("Context has not been set.");
            }

            return TestContext.CurrentContext.Test.Properties["Context"] as Context;
        }
    }
}
