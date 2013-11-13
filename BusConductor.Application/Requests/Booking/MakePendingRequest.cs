﻿using System;

namespace BusConductor.Application.Requests.Booking
{
    public class MakePendingRequest
    {
        public Guid BusId { get; set; }
        public DateTime? PickUp { get; set; }
        public DateTime? DropOff { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public bool IsMainDriver { get; set; }
        public string DrivingLicenceNumber { get; set; }
        public string DriverForename { get; set; }
        public string DriverSurname { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public string VoucherCode { get; set; }
        public bool TermsAndConditionsAccepted { get; set; }
        public bool RestrictionsAccepted { get; set; }
    }
}
