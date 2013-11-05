using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusConductor.UI.ViewModels.Booking
{
    public class ReviewViewModel
    {
        public Guid BusId { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime DropOff { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        //todo: country
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public bool IsMainDriver { get; set; }
        //todo: driver details if not
        //todo: additional drivers.
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        //todo: how did you find us
        //todo: additional extras.
        public string VoucherCode { get; set; }
        public decimal TotalCost { get; set; }
    }
}