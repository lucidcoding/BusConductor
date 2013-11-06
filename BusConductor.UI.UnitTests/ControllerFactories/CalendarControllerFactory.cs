using System;
using BusConductor.Domain.Entities;
using BusConductor.Domain.Enumerations;
using BusConductor.Domain.RepositoryContracts;
using BusConductor.UI.Controllers;
using Moq;

namespace BusConductor.UI.UnitTests.ControllerFactories
{
    public class CalendarControllerFactory
    {
        public Mock<IBusRepository> BusRepository { get; set; }
        public Guid BusId { get; set; }
        public Mock<Bus> Bus { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        public CalendarControllerFactory(int year, int month, int bookingStartDate, int bookingEndDate)
        {
            BusRepository = new Mock<IBusRepository>();
            BusId = Guid.NewGuid();
            Bus = new Mock<Bus>();
            Bus.SetupGet(x => x.Id).Returns(BusId);
            Bus.Setup(x => x.GetBookingStatusFor(It.IsAny<DateTime>())).Returns(BookingStatus.Free);

            for (var day = bookingStartDate; day <= bookingEndDate; day++)
            {
                Bus.Setup(x => x.GetBookingStatusFor(new DateTime(year, month, day))).Returns(BookingStatus.Pending);
            }

            Year = year;
            Month = month;
            BusRepository.Setup(x => x.GetById(BusId)).Returns(Bus.Object);
        }

        public CalendarController GetController()
        {
            return new CalendarController(BusRepository.Object);
        }
    }
}
