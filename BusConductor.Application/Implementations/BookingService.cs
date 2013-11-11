using System;
using BusConductor.Application.Contracts;
using BusConductor.Application.ParameterSetMappers.Booking;
using BusConductor.Application.Requests.Booking;
using BusConductor.Domain.Common;
using BusConductor.Domain.Entities;
using BusConductor.Domain.RepositoryContracts;

namespace BusConductor.Application.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMakePendingParameterSetMapper _makePendingParameterSetMapper;

        public BookingService(
            IBookingRepository bookingRepository,
            IMakePendingParameterSetMapper makePendingParameterSetMapper)
        {
            _bookingRepository = bookingRepository;
            _makePendingParameterSetMapper = makePendingParameterSetMapper;
        }

        public ValidationMessageCollection ValidateMakePending(MakePendingRequest request)
        {
            var parameterSet = _makePendingParameterSetMapper.Map(request);
            var validationMessages = Booking.ValidateMakePending(parameterSet);
            return validationMessages;
        }

        public Booking SummarizePendingBooking(MakePendingRequest request)
        {
            var parameterSet = _makePendingParameterSetMapper.Map(request);
            var booking = Booking.MakePending(parameterSet);
            return booking;
        }

        public Guid MakePending(MakePendingRequest request)
        {
            var parameterSet = _makePendingParameterSetMapper.Map(request);
            var booking = Booking.MakePending(parameterSet);
            _bookingRepository.Save(booking);
            return booking.Id.Value;
        }
    }
}
