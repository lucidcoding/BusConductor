using System;
using BusConductor.Data.Common;
using BusConductor.Domain.Entities;
using BusConductor.Domain.RepositoryContracts;

namespace BusConductor.Data.Repositories
{
    public class BookingRepository : Repository<Booking, Guid>, IBookingRepository
    {
        public BookingRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }
    }
}
