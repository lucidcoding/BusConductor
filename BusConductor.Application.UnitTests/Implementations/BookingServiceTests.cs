using BusConductor.Application.Requests.Booking;
using BusConductor.Application.UnitTests.ServiceFactories;
using BusConductor.Domain.Entities;
using Moq;
using NUnit.Framework;

namespace BusConductor.Application.UnitTests.Implementations
{
    [TestFixture]
    public class ValidateMakePendingTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void ValidateMakePendingCallsCorrectMethods()
        {
            var bookingServiceFactory = new BookingServiceFactory();
            var bookingService = bookingServiceFactory.GetService();
            var request = new MakePendingRequest();
            var booking = bookingService.ValidateMakePending(request);
            bookingServiceFactory.MakePendingParameterSetMapper.Verify(x => x.Map(request), Times.Once());
        }

        [Test]
        public void SummarizePendingBookingCallsCorrectMethods()
        {
            var bookingServiceFactory = new BookingServiceFactory();
            var bookingService = bookingServiceFactory.GetService();
            var request = new MakePendingRequest();
            var booking = bookingService.SummarizePendingBooking(request);
            bookingServiceFactory.MakePendingParameterSetMapper.Verify(x => x.Map(request), Times.Once());
            //bookingServiceFactory.BookingRepository.Verify(x => x.Clear(), Times.Once());
        }

        [Test]
        public void MakePendingBookingCallsCorrectMethods()
        {
            var bookingServiceFactory = new BookingServiceFactory();
            var bookingService = bookingServiceFactory.GetService();
            var request = new MakePendingRequest();
            bookingService.MakePending(request);
            bookingServiceFactory.MakePendingParameterSetMapper.Verify(x => x.Map(request), Times.Once());
            bookingServiceFactory.BookingRepository.Verify(x => x.Save(It.IsAny<Booking>()), Times.Once());
        }
    }
}
