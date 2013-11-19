using System;
using BusConductor.Application.Requests.Booking;
using BusConductor.Domain.Common;
using BusConductor.Domain.Entities;

namespace BusConductor.Application.Contracts
{
    public interface IBookingService
    {
        ValidationMessageCollection ValidateCustomerMake(MakePendingRequest request);
        Booking SummarizeCustomerMake(MakePendingRequest request);
        string CustomerMake(MakePendingRequest request);
    }
}
