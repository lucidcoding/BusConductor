using BusConductor.Application.Requests.Booking;
using BusConductor.Domain.Common;
using BusConductor.Domain.Entities;

namespace BusConductor.Application.Contracts
{
    public interface IBookingService
    {
        ValidationMessageCollection ValidateMakePending(MakePendingRequest request);
        Booking SummarizePendingBooking(MakePendingRequest request);
        void MakePending(MakePendingRequest request);
    }
}
