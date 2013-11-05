using System;

namespace BusConductor.Domain.ParameterSets
{
    public class MakePendingBookingDriverParameterSet
    {
        public Guid Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string DrivingLicenceNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
