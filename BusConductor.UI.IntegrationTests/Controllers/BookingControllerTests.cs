using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusConductor.UI.IntegrationTests.Helpers;
using NUnit.Framework;

namespace BusConductor.UI.IntegrationTests.Controllers
{
    [TestFixture]
    public class BookingControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            ScriptRunner.RunScript();
        }

        [Test]
        public void Works()
        {
            
        }
    }
}
