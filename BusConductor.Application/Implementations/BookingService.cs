using System;
using BusConductor.Application.Contracts;
using BusConductor.Application.ParameterSetMappers.Booking;
using BusConductor.Application.Requests.Booking;
using BusConductor.Domain.Common;
using BusConductor.Domain.Entities;
using BusConductor.Domain.RepositoryContracts;
using Lucidity.Utilities.Contracts.Logging;

namespace BusConductor.Application.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMakePendingParameterSetMapper _makePendingParameterSetMapper;
        private readonly ILog _log;

        public BookingService(
            IBookingRepository bookingRepository,
            IMakePendingParameterSetMapper makePendingParameterSetMapper,
            ILog log)
        {
            _bookingRepository = bookingRepository;
            _makePendingParameterSetMapper = makePendingParameterSetMapper;
            _log = log;
        }

        public ValidationMessageCollection ValidateMakePending(MakePendingRequest request)
        {
            _log.Add(request);
            var parameterSet = _makePendingParameterSetMapper.Map(request);
            var validationMessages = Booking.ValidateMakePending(parameterSet);
            return validationMessages;
        }

        public Booking SummarizePendingBooking(MakePendingRequest request)
        {
            _log.Add(request);
            var parameterSet = _makePendingParameterSetMapper.Map(request);
            var booking = Booking.MakePending(parameterSet);
            return booking;
        }

        public string MakePending(MakePendingRequest request)
        {
            _log.Add(request);
            var parameterSet = _makePendingParameterSetMapper.MapWithOtherBookingsToday(request);
            var booking = Booking.MakePendingWithBookingNumber(parameterSet);
            _bookingRepository.Save(booking);
            return booking.BookingNumber;
        }
    }
}
