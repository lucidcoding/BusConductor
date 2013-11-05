using System;
using BusConductor.Domain.Entities;

namespace BusConductor.Domain.ParameterSets
{
    public class CreateDriverParameterSet
    {
        public Guid Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string DrivingLicenceNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Booking Booking { get; set; }
        public bool IsMainDriver { get; set; }
        public User ApplicationUser { get; set; }
    }
}
