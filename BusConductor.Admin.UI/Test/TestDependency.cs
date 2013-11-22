using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusConductor.Admin.UI.Test
{
    public class TestDependency : ITestDependency
    {
        private Guid _id;

        public TestDependency()
        {
            _id = Guid.NewGuid();
        }

        public Guid GetId()
        {
            return _id;
        }
    }
}
