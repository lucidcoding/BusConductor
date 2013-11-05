using System;
using BusConductor.Domain.Common;
using BusConductor.Domain.Entities;

namespace BusConductor.Domain.RepositoryContracts
{
    public interface IBookingRepository : IRepository<Booking, Guid>
    {
    }
}
