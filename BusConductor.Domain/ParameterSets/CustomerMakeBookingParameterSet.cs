using System;
using System.Collections.Generic;
using BusConductor.Domain.Entities;

namespace BusConductor.Domain.ParameterSets
{
    public class CustomerMakeBookingParameterSet : MakeBookingParameterSet
    {
        public string VoucherCode { get; set; }
        public Voucher Voucher { get; set; }
        public bool TermsAndConditionsAccepted { get; set; }
        public bool RestrictionsAccepted { get; set; }
    }
}
