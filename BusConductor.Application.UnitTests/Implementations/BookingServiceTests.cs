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
            var booking = bookingService.ValidateCustomerMake(request);
            bookingServiceFactory.MakePendingParameterSetMapper.Verify(x => x.Map(request), Times.Once());
        }

        [Test]
        public void SummarizePendingBookingCallsCorrectMethods()
        {
            var bookingServiceFactory = new BookingServiceFactory();
            var bookingService = bookingServiceFactory.GetService();
            var request = new MakePendingRequest();
            var booking = bookingService.SummarizeCustomerMake(request);
            bookingServiceFactory.MakePendingParameterSetMapper.Verify(x => x.Map(request), Times.Once());
        }

        [Test]
        public void MakePendingBookingCallsCorrectMethods()
        {
            var bookingServiceFactory = new BookingServiceFactory();
            var bookingService = bookingServiceFactory.GetService();
            var request = new MakePendingRequest();
            bookingService.CustomerMake(request);
            bookingServiceFactory.MakePendingParameterSetMapper.Verify(x => x.MapWithOtherBookingsToday(request), Times.Once());
            bookingServiceFactory.BookingRepository.Verify(x => x.Save(It.IsAny<Booking>()), Times.Once());
        }

        //todo:check summarize returns expected booking?

        [Test]
        public void MakePendingReturnsCorrectResult()
        {
            var bookingServiceFactory = new BookingServiceFactory();
            var bookingService = bookingServiceFactory.GetService();
            var request = new MakePendingRequest();
            var bookingNumber = bookingService.CustomerMake(request);
            Assert.That(bookingNumber, Is.EqualTo("201310010003_Blue"));
        }
    }
}
