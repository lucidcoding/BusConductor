using BusConductor.Application.Requests.Booking;
using BusConductor.Domain.ParameterSets;

namespace BusConductor.Application.ParameterSetMappers.Booking
{
    public interface IMakePendingParameterSetMapper
    {
        MakePendingBookingParameterSet Map(MakePendingRequest request);
    }
}