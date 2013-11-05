using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusConductor.Domain.RepositoryContracts;
using Moq;

namespace BusConductor.UI.UnitTests.ControllerFactories
{
    public class CalendarControllerFactory
    {
        public Mock<IBusRepository> BusRepository;

        public CalendarControllerFactory()
        {
            BusRepository = new Mock<IBusRepository>();
        }
    }
}
