using BusConductor.Domain.Enumerations;

namespace BusConductor.Domain.ParameterSets
{
    public class AdminMakeBookingParameterSet : MakeBookingParameterSet
    {
        public BookingStatus? Status { get; set; }
        public decimal? TotalCost { get; set; }
        public bool WarningsAcknowledged { get; set; }
    }
}
